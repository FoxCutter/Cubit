.device ATtiny48

;         =====================
; /RESET  | 01 /RESET  PC5 28 | *F      F
; !AOut   | 02 PD0     PC4 27 | *E      G
; !BOut   | 03 PD1     PC3 26 | *D      A
; /LATCH  | 04 PD2     PC2 25 | *C      B
; oHI/oLO | 05 PD3     PC1 24 | *B      C
; NC      | 06 PD4     PC0 23 | *A      D
; +5v     | 07 VCC     GND 22 | GND
; GND     | 08 GND     PC7 21 | *G      E
; DB2     | 09 PB6    AVCC 20 | +5v
; DB3     | 10 PB7     PB5 19 | DB1
; NC      | 11 PD5     PB4 18 | DB0
; *DP     | 12 PD6     PB3 17 | DA3
; /OE     | 13 PD7     PB2 16 | DA2
; DA0     | 14 PB0     PB1 15 | DA1
;         =====================
;
; /Latch = Int0
;
; ISP Header
;  1: MISO	PB4 (18)  2: +5V
;  3: SCK	PB5 (19)  4: MOSI	PB3 (17)
;  5: RESET	PC6 (1)   6: GND

;DA0 - DA3 = Data for Nibble A
;DB0 - DB3 = Data for Nibble B
;/LATCH = Low will latch the data of the bus for display
;/OE output enabled
;oHI/oLO = Sets the active state for all output lines (+5, active hi, gnd active low)

;!AOut, !BOut Active nibble (reverse of the oHI/oLO state)
;*A - *G, *DP = Output segments
;        D              D
;  abcdefPg	  dcbagfPe		  abcdefg-dp
;0b11111100	0b11110101	; 0	0b1111110-0
;0b01100000	0b01100000	; 1	0b0110000-0
;0b11011001	0b10111001	; 2	0b1101101-0
;0b11110001	0b11111000	; 3	0b1111001-0
;0b01100101	0b01101100	; 4	0b0110011-0
;0b10110101	0b11011100	; 5	0b1011011-0
;0b10111101	0b11011101	; 6	0b1011111-0
;0b11100000	0b01110000	; 7	0b1110000-0
;0b11111101	0b11111101	; 8	0b1111111-0
;0b11100101	0b01111100	; 9	0b1110011-0
;0b11101111	0b01111111	; A	0b1110111-1
;0b00111111	0b11001111	; b	0b0011111-1
;0b10011110	0b10010111	; C	0b1001110-1
;0b01111011	0b11101011	; d	0b0111101-1
;0b10011111	0b10011111	; E	0b1001111-1
;0b10001111	0b00011111	; F	0b1000111-1
;
;  aaaaaaaa
; f        b
; f        b
; f        b
; f        b
;  gggggggg
; e        c
; e        c
; e        c
; e        c
;  dddddddd

.def ZH = r30
.def ZL = r31

; Execute if Bit in Register is Set
.macro ebrs
   sbrc @0, @1
.endmacro

; Execute if Bit in Register is Clear
.macro ebrc
   sbrs @0, @1
.endmacro


.equ DataPort             = PORTB
.equ DataPortDirection    = DDRB
;.equ DataPortPins         = PINB

.equ OutputPort           = PORTC
.equ OutputPortDirection  = DDRC
;.equ OutputPortPins       = PINC

.equ ControlPort          = PORTD
.equ ControlPortDirection = DDRD
.equ ControlPortPins      = PIND

.equ AOut 		= PORTD0	; Out
.equ BOut 		= PORTD1	; Out
;.equ Latch 		= PORTD2	; In
.equ HighLow 		= PORTD3	; In
;.equ HighByte 		= PORTD4	; In
;.equ COut 		= PORTD5	; In
.equ DP 		= PORTD6	; Out
.equ OutputEnabled	= PORTD7	; In

.equ ControlOutputMask = (1 << AOut) |  (1 << BOut) | ( 1 << DP)


.def ZeroReg            = r0
.def Scratch            = r16
.def NibbleA		= r17
.def NibbleB		= r18
;.def NibbleC		= r19
;.def NibbleD		= r20
.def Count		= r21
.def Control		= r22
.def Param0		= r23
.def Param1		= r24


.cseg
.org $0000
  rjmp Reset         ; RESET
  rjmp LatchInt	     ; INT0
  reti               ; INT1
  reti               ; PCINT0
  reti               ; PCINT1
  reti               ; PCINT2
  reti;              ; PCINT3
  reti;              ; WDT
  reti;              ; TIMER1_CAPT
  reti;              ; TIMER1_COMPA
  reti;              ; TIMER1_COMPB
  rjmp Tick 	     ; TIMER1_OVF
  reti;              ; TIMER0_COMPA
  reti;              ; TIMER0_COMPA
  reti;              ; TIMER0_OVF
  reti;              ; SPI_STC
  reti;              ; ADC
  reti;              ; EE_RDY
  reti;              ; ANA_COMP
  reti;              ; TWI


Reset:

  ldi Scratch, LOW(RAMEND)
  out SPL, Scratch

  ldi Scratch, HIGH(RAMEND)
  out SPH, Scratch

  clr ZeroReg
  clr NibbleA
  clr NibbleB
  clr Count
  clr Control

  ; Port B - Data In, no pullups
  out DataPortDirection, ZeroReg
  out DataPort, ZeroReg

  ; Port C & Port D, set the outputs to tristate (in with no pullups)
  out ControlPortDirection, ZeroReg
  out ControlPort, ZeroReg

  out OutputPortDirection, ZeroReg
  out OutputPort, ZeroReg

  ; Lock in the High/Low bit
  sbic ControlPortPins, HighLow
    sbi Control, HighLow




  ; Int0 on the falling edge of /LATCH
  ldi Scratch, (1 << ISC01) | (0 << ISC00)
  sts EICRA, Scratch

  ; and enable Int0
  ldi Scratch, (1 << INT0)
  out EIMSK, Scratch


  ; Set the timer to 'Clear Timer on Compare Match' mode and to the default clock source
  lds Scratch, (1 << CTC0) | (0 << CS02)| (0 << CS01) | (1 << CS00)
  out TCCR0A, Scratch

  ; Set the interval
  lds Scratch, 0x7F
  out OCR0A, Scratch

  ; And enable it to trigger when it overflows
  lds Scratch, (1 << TOIE0)
  sts TIMSK0, Scratch

  ; Turn on Interupts
  sei


Loop:
  ; and do nothing...
  sleep
  nop
  rjmp Loop



; -----------------------------------------------------------------------------------
; Turns off output on Ports C and D
DisableOutput:
  ; If output is already disabled just return
  ebrc Control, OutputEnabled
    ret

  ; Go back to Tri-state (setting everything to input no pullups)
  out ControlPortDirection, ZeroReg
  out ControlPort, ZeroReg

  out OutputPortDirection, ZeroReg
  out OutputPort, ZeroReg

  cbr Control, OutputEnabled

  ret

; -----------------------------------------------------------------------------------
; Turns On output on Ports C and a few pins on port D
EnableOutput:

  ; If output is already enabled just return
  ebrs Control, OutputEnabled
    ret

  ; Set the output fileds to be output, and the data to zero/no pullups for the rest
  ldi Scratch, ControlOutputMask
  out ControlPortDirection, Scratch
  out ControlPort, ZeroReg


  ; Set these to all output, zero out the data
  ldi Scratch, 0xFF
  out OutputPortDirection, Scratch
  out OutputPort, ZeroReg

  ; Set that output in enabled
  sbr Control, OutputEnabled

  ret

; -----------------------------------------------------------------------------------
; Sets the output for the chip (1 is On, 0 is Off)
;
; Input:
; Param0 Output Port
; Param1 Control Port

SetOutput:
  ; If the OutputEnabled flag is off, just return
  ebrc Control, OutputEnabled
    ret

  andi Param0, 0xBF ; Mask off the reset pin, just in case
  andi Param1, ControlOutputMask

  out OutputPort, Param0
  out ControlPort, Param1

  ret


; -----------------------------------------------------------------------------------

LatchInt:
  in r10, ControlPort
  in r11, DataPort

  ; Lov Nibble
  mov Scratch, r11
  andi Scratch, 0x0F
  mov NibbleA, Scratch

  ; High nibble
  swap r11
  mov Scratch, r11
  andi Scratch, 0x0F
  mov NibbleB, Scratch

  reti

; -----------------------------------------------------------------------------------

Tick:
  ; Check the state of /OE
  in Scratch, ControlPortPins

  ebrc Scratch, OutputEnabled
    rcall EnableOutput

  ebrs Scratch, OutputEnabled
    rcall DisableOutput

  clr Param0
  clr Param1

  ; Move to the next nibble
  inc Count

  ; Decide on the nibble based on the low bit
  ebrs Count, 0
    breq OutB

  ; Populate the data from NibbleA
  mov Param0, NibbleA
  sbr Param1, AOut
  rjmp SegementLookup

OutB:
  ; Populate the data from NibbleB
  mov Param0, NibbleB
  sbr Param1, BOut
  rjmp SegementLookup


SegementLookup:
  ; Setup the Segement table pointer
  ldi Scratch, HIGH(SegmentTable)
  out ZH, Scratch
  ldi Scratch, LOW(SegmentTable)
  out ZL, Scratch

  ; Add the offset to it
  add ZL, Param0

  ; Load the value from program memory
  LPM Param0, Z

  ; Right now all bits are set if they are active, so we need to flip something

  ; if the HighLow bit is clear, the segement output is Active low and OutA/B is active high
  ebrc Control, HighLow
    com Param0

  ; if the HighLow bit is set, the segement output is Active high and OutA/B is active low
  ebrs Control, HighLow
    com Param1

  ; If the DP bit is set, set it in Param1
  ebrs Param0, DP
    sbr Param1, DP

  ; Output the value
  rcall SetOutput

  reti

; -----------------------------------------------------------------------------------

SegmentTable:
     ;   D              
     ;  gPfedcba 	  abcdefg-dp
  .DW 0b00111111 ; 0	0b1111110-0
  .DW 0b00000110 ; 1	0b0110000-0
  .DW 0b10011011 ; 2	0b1101101-0
  .DW 0b10001111 ; 3	0b1111001-0
  .DW 0b10100110 ; 4	0b0110011-0
  .DW 0b10101101 ; 5	0b1011011-0
  .DW 0b10111101 ; 6	0b1011111-0
  .DW 0b00000111 ; 7	0b1110000-0
  .DW 0b10111111 ; 8	0b1111111-0
  .DW 0b10100111 ; 9	0b1110011-0
  .DW 0b11110111 ; A	0b1110111-1
  .DW 0b11111100 ; b	0b0011111-1
  .DW 0b01111001 ; C	0b1001110-1
  .DW 0b11011110 ; d	0b0111101-1
  .DW 0b11111001 ; E	0b1001111-1
  .DW 0b11110001 ; F	0b1000111-1
  
  
;     ;   D  
;     ;  ePfgabcd 	  abcdefg-dp
;  .DW 0b10101111 ; 0	0b1111110-0
;  .DW 0b00000110 ; 1	0b0110000-0
;  .DW 0b10011101 ; 2	0b1101101-0
;  .DW 0b00011111 ; 3	0b1111001-0
;  .DW 0b00110110 ; 4	0b0110011-0
;  .DW 0b00111011 ; 5	0b1011011-0
;  .DW 0b10111011 ; 6	0b1011111-0
;  .DW 0b00001110 ; 7	0b1110000-0
;  .DW 0b10111111 ; 8	0b1111111-0
;  .DW 0b00111110 ; 9	0b1110011-0
;  .DW 0b11111110 ; A	0b1110111-1
;  .DW 0b11110011 ; b	0b0011111-1
;  .DW 0b11101001 ; C	0b1001110-1
;  .DW 0b11010111 ; d	0b0111101-1
;  .DW 0b11111001 ; E	0b1001111-1
;  .DW 0b11111000 ; F	0b1000111-1
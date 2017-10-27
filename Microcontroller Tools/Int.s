;https://code.google.com/p/chirico/source/browse/trunk/Arduino/tn48def.inc

.device ATtiny48
;.nolist
;.include "tn48def.inc"
;.list
;               AtTiny48
;         =====================
; /RESET  | 01 /RESET  PC5 28 | IRQ5
; A0      | 02 PD0     PC4 27 | IRQ4
; A1      | 03 PD1     PC3 26 | IRQ3
; /CE     | 04 PD2     PC2 25 | IRQ2
; /INTACK | 05 PD3     PC1 24 | IRQ1
; /INTREQ | 06 PD4     PC0 23 | IRQ0
; +5v     | 07 VCC     GND 22 | GND
; GND     | 08 GND     PC7 21 | IRQ7
; D6      | 09 PB6    AVCC 20 | +5v
; D7      | 10 PB7     PB5 19 | D5
; /WAIT   | 11 PD5     PB4 18 | D4
; IRQ6    | 12 PD6     PB3 17 | D3
; RD/WD   | 13 PD7     PB2 16 | D2
; D0      | 14 PB0     PB1 15 | D1
;         =====================
;
; /CS    = INT0
; INTACK = INT1
;
; ISP Header
;  1: MISO	PB4 (18)  2: +5V
;  3: SCK	PB5 (19)  4: MOSI	PB3 (17)
;  5: RESET	PC6 (1)   6: GND
;
;  SCL  - PC5 (28)
;  SDA  - PC4 (27)
;
;  SCK  - PB5 (19)
;  MISO - PB4 (18)
;  MOSI - PB3 (17)
;  SS   - PB2 (16)
;
; ===================================================================================
;
; General Interrupt Controller
;
; Provides priority based interrupt service to a CPU that takes vectored interrupts.
;
; A0-A1: Selects the port to address, IN
; D0-D7: Data Bus, I/O
; /IRQ0-/IRQ7: Interrupt Request lines, edge triggered low, IN
; /CE: Chip enable, IN
; RD/WD: 1: Read, 0: Write, IN
; /WAIT: Set to low when the MCU is Reading/Writing the databus, OUT
; /INTREQ: Output line, goes low when the MCU wants to deliver an interrupt, OUT
; /INTACK: Sent from the CPU when it's time to write out the vector data to the bus, IN
;
; Future plans:
;  * 3 Different INTA modes
;    * Mode 0 = Z80 (Send Vector on INTA)
;    * Mode 1 = 8086/8088 (Set ISR on INTA1, second vector on INTA2)
;    * Mode 2 = 8080 (Jump on INTA1, Low Byte on INTA2, High Byte on INTA3)
;    * Mode 3 = Multi Byte data, one byte per an INTA
;    * Mode 4 = Polling Mode (Next RD will be treated as the INTA)
;  * INTREQ Active Level select (0 = Low, 1 = High)
;  * IRQ Active Level select (0 = Low, 1 = High)
;  * Edge or Level tiggered mode on IRQs
;  * Automatic End of Interrupt (Per IRQ?)
;  * Priority Rotation
;  * EOI of Specific IRQs
;  * Cascading Interrupts
;
; CS | A0 | A1 | Read (1)    | Write (0)
; ------------------------------------------
;  0 |  0 |  0 | ISR         | Command
;  0 |  0 |  1 | IMR         | IMR
;  0 |  1 |  0 | Register ID | Register ID
;  0 |  1 |  1 | Data        | Data
;  1 |  X |  X | ----------- | -------------
;
; IRQx        : IRQ0 = Bit 0, IRQ1 = Bit 1, etc.
;
; All undefined bit values should be 0
;
; ISR         : *7-*0: IRQx is (1) In Service, (0) Not in service
; IMR         : *7-*0: IRQx is (1) Enabled, (0) Disabled
; Command     :
;              7|6|5|4|3|2|1|0
;              c|c|c|x|x|x|x|x: ccc = Command, xxx = data
;              0|0|0|-|-|-|-|X: Master Enable, Sets the master interrupt enable to X
;              1|0|0|m|m|v|v|v: End of Interrupt (MM = mode, 00 = all, 01 = Specific. VVV Specific Interrupt)
;              1|1|0|x|x|x|x|x: Debug Commands
;              1|1|1|-|-|-|-|-: Soft Reset
; Register ID : Register to edit
; Data        : Register data
;
; Register     (ID)
; Status       (00) ---- Read Only
;                   : *7: Master Interrupts Enabled
;
; Configure:   (01)
;                   : *6: INTREQ Low/High
;                   : *5: IRQ Low/High
;                   : *4: IRQ Trigger: (0) Level Triggered, (1) Edge Triggered --- Not Yet Implemented
;                   ; *3: Priority mode (0) Fixed (1) Rotating  --- Not Yet Implemented
;                     *2-0: Mode                  -- Not Yet Implemented
; IRR          (02) : *7-*0 IRQx has (1) Requested service (0) Not requested service. Read Only
; AUTO EOI     (03) : *7-*0 IRQx will (1) auto EOI (0) not auto EOI
;
; Vectors      (08) : *3: (0) Vector Range, (1) Individual Vectors
;                     *0-*2: Vector Skip value, when Bit 3 is 0, this value (+1) is used to build the vector table
; IRQx Vector  (1x) : Vector for given IRQ, if Vectors[3] is 0, this is the base vector all the other vectors are built on.
;                   : When Vectors[3] is 0 you can still read from all registers to get the current vector
; Spurious Int (1F) : Vector to give in the case of a Spurious Interrupt
;
; Reset Values:
;  IRQ0 = 0x80
;  IRQ1 = 0x82
;  IRQ2 = 0x84
;  IRQ3 = 0x86
;  IRQ4 = 0x88
;  IRQ5 = 0x8A
;  IRQ6 = 0x8C
;  IRQ7 = 0x8E
;  Spurious Int = 0xF0
;  All other registers are set to 0x00
; Mode 0, INTREQ Low, IRQ Low, Level Tiggered
; INTREQ and WAIT will be floating until activated
; Master Interupts off, all masked off
;
; * An IRQ Line is triggered so set the debouce timer
; * On debouce get the active IRQs, and decide which ones to act on
; * Set the active bits in the IRR (if Edge mode, clear the IRR bits if not active, in level mode never clear)
; * If Enabled and IMR is on, set INTREQ
; * Recive the INTA
;   Mode 0=Set the ISR bit and write out the vector. Auto EIO if selecetd
;   Mode 1=INTA1, set the ISR bit. INTA2 Write out the vector Auto EIO if selecetd
;   Mode 2=INTA1, Set the ISR bit, write out Jump. INTA2=Low Byte, INTA3=High Byte, Auto EIO if selecetd
;   Mode 3=INTA1, Set the ISR bit Write out first byte of data, INTAx, write out remaining bytes, one per INTA,last INTA Auto EIO if selecetd
;   Mode 4=INTA is ignored, the next Read will be treated as INTA and set the related ISR bit.
; * EIO/Auto EIO, if level, check if the IRQ line is still active, and if true reset it in the IRR.

;
; Notes for cascading interrupts...
; With the lack of free pins on the DIP Tiny48, we don't have a huge number of options on how to
;  cascade them together.
;
; The best choice is probably to use the TWI interface to connect all the chips together, and the INTREQ
; line on the child will connect to an IRQ line on the parent. This will give us 6 IRQs per a chip, and allow
; for 64 total IRQs. We would lose IRQ 4 and 5 on each chip as a side effect, but I think it works in balance.
; An upshot, you can have all the commands going to the master and being sent to all the child chips so you
; set them up indivitualy, but control them via a single point.
;
; Old options
;
;  1 Each slave is connected only to the IRQx pin on the master, but duplexed between the
;    /INTREQ (out) and /INTACK (in) on the slave. This will allow 64 Ints
;
;  2 Each slave is connected to two IRQ pins, one to /INTREQ and the other to /INTACK.
;    (IRQ0,1 for Slave 0, IRQ2,3 for Slave 1) This will gives us a max of 32 ints.
;
;  3 Each slave is connected to a single IRQ pin, but every chip is on a private I2C Bus. This
;    Uses two extra IRQ pins on each chip, but the /INTACK pin on the slave chips would not be used
;    which can allow us to snag it for an extra IRQ. This will give us between 36 and 42 ints.
;
;    Using the I2C bus also allows an extra level of comunication between each chip, but at an extra
;    setup cost. It could also in theroy allow us to have more complicated cascading, or even have
;    more then one Slave on a master IRQ line.
;
; If we require the use of the 32-pin quad package of the Tiny48 (with 4 more pins) to cascade
;  we have a couple more options.
;
;  4 Each Slave is connected to the master IRQ line, and one of the new pins, this will only allow
;    4 slave chips, providing 36 total ints.
;
;  5 Each slave is connected to a master IRQ line. Three of the new pins are connected to every chip
;    while the 4th extra pin is connected to each slaves /INTACK line. When sending INTACK to the
;    slaves it will put the ID of the acutal slave to talk onto the three pins, allowing it to
;    select one slave. This gives up 64 possible ints.
;
;  6 The same as option 3 above, but use two of the new pins to replace the missing IRQ pins, this
;    will leave us with the usual 64 ints.
;
; If we only want to support a single slave (allowing for 15 ints) to mimic the PC-AT we have two more
;  options;
;
;  7 Like 2 above, allowing the outgoing IRQ line to be sellected.
;
;  8 Like 4 above, but connect one free pin to the slaves INTACK line.
;
; And just one Crazy idea
;
;  9 Like 3 above, but insted of other Controlers connect the private I2C bus to a number of
;    I/O extenders. Each extender (up to 6) will connect to the IRQ line on the master and the master
;    will manage them. As you can get I/O extenders with 16 pins, this can allow for up to 96 ints
;    at the cost of making the master manage a lot more data. This would probably need a full k of
;    RAM to work at the max.
;
; My prefence is for choice 1, simply because it's the easist to make work with the existing code
; and while it does have a problem with the duplexed line, I don't think it's insurmountable. I think
; if the slave sets the IRQ line low to indicate it has a pending int, the master can then pull it back
; high for the ACK. The slave would have to know it's state and couldn't set the IRQ line high until
; EOI has been recived.
;
; There can be up to 9 chips. the Master, and 8 Slave chips.
; Each slave's INTREQ line will be connected to an IRQ line on the master, this will dictate
;  the priority of slaves. (IE, Slave0 > Slave1 > Slave2). Internally this works the same
;  with or without a slave.
; The IntAck is only connected to the Master chip.
;


; ===================================================================================
;
; The official Assembler knows YH, YL, ZH, ZL, but gavrasm doesn't when using the .device directive.
;
.def YH = r28
.def YL = r29
;.def ZH = r31
;.def ZL = r30

; ===================================================================================
;
; Macros for inversing sbrc/s so you can say 'execute command' insted of 'skip'
; as the actal logic hurts my head.

; Execute if Bit in Register is Set
.macro ebrs
   sbrc @0, @1
.endmacro

; Execute if Bit in Register is Clear
.macro ebrc
   sbrs @0, @1
.endmacro

; Execute if Bit in I/O Register is Set
.macro ebis
   sbic @0, @1
.endmacro

; Execute if Bit in I/O Register  is Clear
.macro ebic
   sbis @0, @1
.endmacro

; Branch if Zero
.macro brez
   breq @0
.endmacro

; Branch if not Zero
.macro brnz
   brne @0
.endmacro

.macro CallTo
   ldi ZL, LOW( @0 )
   ldi ZH, HIGH( @0 )

   add ZL, @1
   adc ZH, ZeroReg

   icall
.endmacro

; ===================================================================================
;   Constants and registers
; ===================================================================================

.equ DataPort             = PORTB
.equ DataPortDirection    = DDRB
.equ DataPortPins         = PINB

.equ IRQPort              = PORTC
.equ IRQPortDirection     = DDRC
.equ IRQPortPins          = PINC

.equ ControlPort          = PORTD
.equ ControlPortDirection = DDRD
.equ ControlPortPins      = PIND

.equ IRQ0 = PORTC0
.equ IRQ1 = PORTC1
.equ IRQ2 = PORTC2
.equ IRQ3 = PORTC3
.equ IRQ4 = PORTC4
.equ IRQ5 = PORTC5
.equ IRQ6 = PORTD6      ; On port D insted of C
.equ IRQ7 = PORTC7

; Data port bits
.equ A0             = PORTD0
.equ A1             = PORTD1
.equ ADDRESS_MASK   = (1 << A1) | (1 << A0)
.equ CHIP_ENABLE    = PORTD2
.equ INT_ACK        = PORTD3
.equ INT_REQ        = PORTD4
.equ BUS_WAIT       = PORTD5
.equ READ_WRITE     = PORTD7


.equ ReadISR_WriteCommand = 0b00
.equ ReadWriteIMR         = 0b01
.equ ReadWriteRegister    = 0b10
.equ ReadWriteData        = 0b11

; Commands
.equ CommandMask         = 0xE0

.equ MasterEnableCommand = 0x00
.equ EOICommand 	 = 0x80
.equ DebugCommand 	 = 0xC0
.equ SoftResetCommand	 = 0xE0

; Status Bits
.equ MasterInterruptEnable = 7
.equ OutputData            = 6
;.equ ByteCountMask      = 0x07


; Config Register bits
.equ MODE_Mask          = 0x07
;.equ Priority_Mode	= 3
.equ IRQ_Trigger        = 4
.equ IRQ_Level          = 5
.equ INT_REQ_Level      = 6

.equ Mode_Z80 		= 0
;.equ Mode_i86 		= 1
;.equ Mode_i80 		= 2
;.equ Mode_MultiByte 	= 3
.equ Mode_Polling 	= 4

; Vector Register Bits
.equ VectorSkipMask    = 0x07
.equ IndividualVectors = 3


; Register IDs
.equ RegisterSatus       = 0x00
.equ RegisterConfig      = 0x01
.equ RegisterIRR         = 0x02
.equ RegisterAutoEOI     = 0x03
.equ RegisterVectors     = 0x08
;.equ RegisterDebug       = 0x42
.equ RegisterVectorBase  = 0x10
.equ RegisterSpuriousInt = 0x1F

; Globals
.def ZeroReg            = r0
.def IOData             = r15
.def Scratch            = r16

.def StatusRegister     = r17
.def ConfigureRegister  = r18
;r19
;r20
;r21
;r22
.def ISR                = r23
.def IRR                = r24
.def IMR                = r25
.def CurrentRegister    = r26
.def OldIRQs            = r27

; Function Parameters
.def Param0             = r13
.def Param1             = r14


; ===================================================================================
; Interrupt Table

.cseg
.org $0000
  rjmp Reset         ; RESET
  rjmp ChipEnableInt ; INT0
  rjmp IntAckInt     ; INT1
  reti               ; PCINT0
  rjmp IRQChangeInt  ; PCINT1
  rjmp IRQChangeInt  ; PCINT2
  reti;              ; PCINT3
  reti;              ; WDT
  reti;              ; TIMER1_CAPT
  reti;              ; TIMER1_COMPA
  reti;              ; TIMER1_COMPB
  rjmp DebounceTimerInt ; TIMER1_OVF
  reti;              ; TIMER0_COMPA
  reti;              ; TIMER0_COMPA
  reti;              ; TIMER0_OVF
  reti;              ; SPI_STC
  reti;              ; ADC
  reti;              ; EE_RDY
  reti;              ; ANA_COMP
  reti;              ; TWI

; ===================================================================================
;   Setup/Reset the System
; ===================================================================================

Reset:
  ; Clear any watch dog that might have reset us
  wdr
  clr ZeroReg

  ; Clear WDRF in MCUSR
  in Scratch, MCUSR
  andi Scratch, (0xFF & (1 << WDRF))
  out MCUSR, Scratch

  ; Keep old prescaler setting to prevent unintentional time-out
  lds Scratch, WDTCSR
  ori Scratch, (1<<WDCE) | (1<<WDE)
  sts WDTCSR, Scratch

  ; Turn off WDT
  sts WDTCSR, ZeroReg

  ; init stack pointer at the top of RAM
  ldi Scratch, LOW(RAMEND)
  out SPL, Scratch

  ldi Scratch, HIGH(RAMEND)
  out SPH, Scratch

  ; -------
  ; Clear out the Registers
  clr StatusRegister
  clr ConfigureRegister
  clr ISR
  clr IRR
  clr IMR
  clr CurrentRegister
  clr OldIRQs
  sts AutoEOIRegister, ZeroReg
  sts VectorRegister, ZeroReg


  ; -------
  ; Configure the ports

  ; Port B - Data In/Out, so leave it floating
  out DataPortDirection, ZeroReg
  out DataPort, ZeroReg

  ; Port C - IRQ In, leave floating
  out IRQPortDirection, ZeroReg
  out IRQPort, ZeroReg

  ; Port D - Control. Leave everything in/floating until master enable is flipped.
  out ControlPortDirection, ZeroReg
  out ControlPort, ZeroReg


  ; -------
  ; Build the default vectors
  ldi Scratch, 0x80 ; Base Vector
  mov Param0, Scratch

  ldi Scratch, 2 ; Skip Value
  mov Param1, Scratch

  rcall SetVectors

  ldi Scratch, 0xF0
  sts BadVector, Scratch


  ; -------
  ; Timer Setup

  ; Set the timer to the default clock source
  lds Scratch, (0 << CS02) | (0 << CS01) | (1 << CS00)
  out TCCR0A, Scratch

  ; Clear out the counter
  out TCNT0, ZeroReg


  ; -------
  ; Interrupt setup

  ; Pin Change Interupts on Port C (pins 0-5 & 7)
  ldi Scratch, (1 << IRQ0) | (1 << IRQ1) | (1 << IRQ2) | (1 << IRQ3) | (1 << IRQ4) | (1 << IRQ5) | (1 << IRQ6) | (1 << IRQ7)
  sts PCMSK1, Scratch

  ; Pin Change Interupts on Port D pin 6
  ldi Scratch, 1 << IRQ6
  sts PCMSK2, Scratch

  ; Set INT0 and INT1 to triger on change (01)
  ldi Scratch, (1 << ISC00) | (1 << ISC10)
  sts EICRA, Scratch

  ; Enable Int0
  ldi Scratch, 0x01;
  out EIMSK, Scratch

  ; Turn on Interrupts
  sei

Loop:
  ; and do nothing, everything else is handlede with ints
  sleep
  nop
  rjmp Loop

; ===================================================================================
;   Interrupt Handlers
; ===================================================================================


IRQChangeInt:
  ; Clear out the counter
  out TCNT0, ZeroReg

  ; And any pending interrupts that might have come up
  ldi Scratch, (1 << TOV0)
  out TIFR0, Scratch

  ; Enable the timer
  ldi Scratch, 1 << TOIE0
  sts TIMSK0, Scratch

  reti

; ------------------------------------------------------------------------------------

DebounceTimerInt:
  ; Disable the Timer
  sts TIMSK0, ZeroReg

  ; < Param0 = Active IRQs
  ;rcall GetIRQData

  ; Save the old Request register
  ;mov r9, IRR

  ; Latch the changed IRQ lines
  ;or IRR, Param0

  ; Pull out the bits that changed (IRR xor OldIRR)
  ;mov Param0, IRR
  ;eor Param0, r9

  ; And fire the ints that have changed.
  ; > Param0 = Bitmap of IRQs that have gone active
  ;rcall SetIntReqAsNeeded

  reti

; ------------------------------------------------------------------------------------

IntAckInt:
  in r10, ControlPortPins

  ; If IntAck is high, clear the data port and be done
  ebrs r10, INT_ACK
     rjmp ClearDataPortAndReturn

  ; Turn off the Int request line
;  sbi ControlPort, INTREQ

  ; Turn on the /WAIT line
;  cbi ControlPort, BUS_WAIT

  ; if nothing is set, write out BadVector
;  cpi IRR, 0
;  breq IA_Spuriouse

  ; Find the highest priority interupt in the IRR
  ; > Param0 = IRR Bitmap
  ; < Param0 = Vector
  ; < Param1 = Bitmask
;  mov Param0, IRR
;  rcall SelectIRQ

  ; Set the bit in ISR
;  or ISR, Param1

  ; clear bit in IRR
;  com Param1
;  and IRR, Param1

;  rjmp IA_Complete

;IA_Spuriouse:
;  lds Param0, BadVector

;IA_Complete:
  ; Write out the response
;  rcall OutputDataPort

  ; We will clear the port when Int line goes high

  ; Turn off the /WAIT line
;  sbi ControlPort, BUS_WAIT

;  reti

; ------------------------------------------------------------------------------------

ChipEnableInt:
  in Scratch, ControlPortPins

  ; If /CE is high, clear all the output and return
  ebrs Scratch, CHIP_ENABLE
    rjmp ClearDataPortAndReturn

  ; Turn on the /WAIT line
  cbi ControlPort, BUS_WAIT

  ; If RD/WR isn't low, set the OutputData status flag
  sbrc Scratch, READ_WRITE
    sbr StatusRegister, 1 << OutputData

  clr IOData
  ebrc StatusRegister, OutputData
    in IOData, DataPortPins

  ; Pull out the address lines
  andi Scratch, ADDRESS_MASK

  cpi Scratch, ReadISR_WriteCommand
  breq CE_ISR

  cpi Scratch, ReadWriteIMR
  breq CE_IMR

  cpi Scratch, ReadWriteRegister
  breq CE_Register

  cpi Scratch, ReadWriteData
  breq CE_Data

;-------------- 00 --------------

CE_ISR:
  ; if Read/Write is clear we handle a command
  ebrc StatusRegister, OutputData
    rjmp CE_Command

  mov IOData, ISR

  rjmp CS_Complete

;-------------- 01 --------------

CE_IMR:
  ; if Read/Write is clear we save the value
  ebrc StatusRegister, OutputData
    mov IMR, IOData

  ; if Read/Write is set we return the value
  ebrs StatusRegister, OutputData
    mov IOData, IMR

  rjmp CS_Complete

;-------------- 10 --------------

CE_Register:
  ; if Read/Write is clear we save the value
  ebrs StatusRegister, OutputData
    mov IOData, CurrentRegister

  ebrc StatusRegister, OutputData
    mov CurrentRegister, IOData

  rjmp CS_Complete

;-------------- 11 --------------

CE_Data:
  cpi CurrentRegister, RegisterSatus
  breq RegisterSatusHandler

  cpi CurrentRegister, RegisterConfig
  breq RegisterConfigHandler

  cpi CurrentRegister, RegisterIRR
  breq RegisterIRRHandler

  cpi CurrentRegister, RegisterAutoEOI
  breq RegisterAutoEOIHandler

  cpi CurrentRegister, RegisterVectors
  breq RegisterVectorsHandler

  cpi CurrentRegister, RegisterSpuriousInt
  breq RegisterSpuriousIntHandler

  cpi CurrentRegister, RegisterVectorBase
  breq RegisterVectorsBaseHandler
  brge RegisterVectorsRangeHandler

  rjmp RegisterError


CE_Command:
  mov Param0, IOData
  rcall ExecuteCommand

  rjmp CS_Complete


RegisterSatusHandler:
  ; This one is read only
  ebrs StatusRegister, OutputData
    mov IOData, StatusRegister

  rjmp CS_Complete

RegisterConfigHandler:
  ; Write
  ebrc StatusRegister, OutputData
    mov ConfigureRegister, IOData

  ; Read
  ebrs StatusRegister, OutputData
    mov IOData, ConfigureRegister

  rjmp CS_Complete

RegisterIRRHandler:
; This one is read only
  ebrs StatusRegister, OutputData
    mov IOData, IRR

  rjmp CS_Complete

RegisterAutoEOIHandler:
  ; Write
  ebrc StatusRegister, OutputData
    sts AutoEOIRegister, IOData

  ; Read
  ebrs StatusRegister, OutputData
    lds IOData, AutoEOIRegister
  rjmp CS_Complete

RegisterVectorsHandler:
  ; Write
  ebrc StatusRegister, OutputData
    sts VectorRegister, IOData

  ; Read
  ebrs StatusRegister, OutputData
    lds IOData, VectorRegister

  rjmp CS_Complete

RegisterSpuriousIntHandler:
  ; Write
  ebrc StatusRegister, OutputData
    sts BadVector, IOData

  ; Read
  ebrs StatusRegister, OutputData
    lds IOData, BadVector

  rjmp CS_Complete

RegisterVectorsBaseHandler:
  ; If it's read, just grab the data from RAM and return
  ebrs StatusRegister, OutputData
    lds IOData, VectorTable
  ebrs StatusRegister, OutputData
    rjmp CS_Complete

  lds Scratch, VectorRegister

  ; If they are doing range vectors, just jump to that code
  ebrc Scratch, IndividualVectors
    rjmp SetupRange

  ; Otherwise we are saving the value the return
  sts VectorTable, IOData
  rjmp CS_Complete

SetupRange:

  mov Param0, IOData ; Base Vector

  andi Scratch, VectorSkipMask
  mov Param1, Scratch
  inc Param1

  rcall SetVectors

  rjmp CS_Complete


RegisterVectorsRangeHandler:
  ldi YH, HIGH(VectorTable)
  ldi YL, LOW(VectorTable)

  mov Scratch, CurrentRegister
  subi Scratch, RegisterVectorBase

  ; Make sure the value is 0-7
  cpi Scratch, 8
  brsh RegisterError

  ; Add the offset
  add YL, Scratch

  ; Write
  ebrc StatusRegister, OutputData
    st Y, IOData

  ; Read
  ebrs StatusRegister, OutputData
    ld IOData, Y

  rjmp CS_Complete

RegisterError:
  ser Scratch
  mov IOData, Scratch
  rjmp CS_Complete

CS_Complete:

  ; Output any requested data
  ebrs StatusRegister, OutputData
    rcall OutputIOData

  ; Turn Off the /WAIT line
  sbi ControlPort, BUS_WAIT

  reti

; -----------------------------------------------------------------------------------
; Executes a command
;
; Param0 = Command
ExecuteCommand:
  mov Scratch, Param0
  andi Scratch, CommandMask

  cpi Scratch, MasterEnableCommand
  breq EC_MasterEnable

  cpi Scratch, EOICommand
  breq EC_EOI

  cpi Scratch, DebugCommand
  breq EC_Debug

  cpi Scratch, SoftResetCommand
  breq EC_Reset

EC_MasterEnable:
  ebrs Param0, 0
    rcall MasterEnable

  ebrc Param0, 0
    rcall MasterDisable

  ret

EC_EOI:
  rcall ExecuteEOI
  ret

EC_Debug:
  ret

EC_Reset:
  rcall SoftReset
  ret


; -----------------------------------------------------------------------------------
; Executes EOI
; Param0 = Options (ignored for now)

ExecuteEOI:
  ; Find the IRQ to clear, the mask is in Param1
  ; < Param1 = Maks of highest priority active IRQ
  ;rcall FindActiveInterrupt

  ; Clear it out of the ISR
  ;com Param1
  ;and ISR, Param1

  ; Get the state fo the IRQ lines
  ; < Param0 = Active IRQs
  ;rcall GetIRQData

  ; Latch the changed IRQ lines
  ;or IRR, Param0

  ; Fire an int for anything that's pending that's not blocked by a higher prority int.
  ;mov Param0, IRR

  ; > Param0 = Bitmap of IRQs that have gone active
  ;rcall SetIntReqAsNeeded

  ret


; ===================================================================================
;    Utility Functions
; ===================================================================================

; -----------------------------------------------------------------------------------
; Enables the system, enabling the INT_REQ and BUS_WAIT pins for output and activates
; INTREQ and Pin Change Interrupts
;
MasterEnable:
  sbr StatusRegister, (1 << MasterInterruptEnable)

  ; Set up the output pins on the Control Port (Port D)
  ldi Scratch, (1 << INT_REQ) | (1 << BUS_WAIT); INTREQ is set to output
  out ControlPortDirection, Scratch

  ldi Scratch, (1 << BUS_WAIT) ; BUS_WAIT is always active low, so set it high.

  ; If INTREQ is achive low, set it high, otherwise leave low
  ebrc ConfigureRegister, INT_REQ_Level
    sbr Scratch, (1 << INT_REQ)

  out ControlPort, Scratch

  ; Enable INT1
  sbi EIMSK, INT1

  ; Enable the Pin change Interrupts
  ldi Scratch, (1 << PCIE1) | (1 << PCIE2)
  sts PCICR, Scratch

  ret

; -----------------------------------------------------------------------------------
; Disables the system, turs out all output pins and disables and clears the INTREQ and
; Pin change interrupts

MasterDisable:
  cbr StatusRegister, (1 << MasterInterruptEnable)

  ; Set all ports to input/floating

  ; Set Port D to all input and floating
  out ControlPortDirection, ZeroReg
  out ControlPort, ZeroReg

  ; Disable INT1
  cbi EIMSK, INT1

  ; And the pin change Interrupts
  sts PCICR, ZeroReg

  ; And the Timer
  sts TIMSK0, ZeroReg


  ; And clear out any pending Interrupts for INT1
  ldi Scratch, 1 << INTF1;
  out EIFR, Scratch

  ; Pin Change
  ldi Scratch, (1 << PCIF1) | (1 << PCIF2);
  out PCIFR, Scratch

  ; And Timer
  ldi Scratch, (1 << TOV0)
  out TIFR0, Scratch

  ret

; -----------------------------------------------------------------------------------
; Loads the state of the IRQ pins
;
; GetIRQData ();
; Param0 = Bitmap of active IRQs

GetIRQData:
  ; Read IRQs from Ports
  in Param0, IRQPortPins

  ; Make sure IRQ6 is moved over as well
  in Scratch, ControlPortPins
  bst Scratch, IRQ6
  bld Param0, IRQ6

  ; If we are active low, flip the IRQs so they are active high
  ebrc ConfigureRegister, IRQ_Level
    com Param0

  ret;

; -----------------------------------------------------------------------------------
; Sets all the vectors based on a base value
;
; SetVectors (Base, Skip)
; Param0 = Base
; Param1 = Skip

SetVectors:
  push YH
  push YL

  ldi YH, HIGH(VectorTable)
  ldi YL, LOW(VectorTable)

  ldi Scratch, 0x08

VectorLoop:
  st Y+, Param0
  add Param0, Param1
  dec Scratch

  brne VectorLoop

  pop YL
  pop YH

  ret

; -----------------------------------------------------------------------------------
; Raises the IntReq if an int is masked
;
; SetIntReqAsNeeded (ActiveInts)
; Param0 = ActiveInts

SetIntReqAsNeeded:
  ; If the master Interrept flag is clear just bail now
;  ebrc MasterRegister, MasterInterruptEnable
;     ret

  ; And it against the mask to find out which ones can even fire, if it's 0
  ; just end
;  and Param0, IMR
;  brez SetInt_End

  ; If nothing is in services just fire off the int.
;  cpi ISR, 0
;  breq SetInt_Fire

  ; Find the next IRQ to call based on the active int
;  rcall SelectIRQ

  ; If ISP >= Param1 (the mask of the highest pending IRQ) don't fire.
;  cp ISR, Param1
;  brsh SetInt_End

;SetInt_Fire:
  ; Okay, we have something to fire, so clear the IntReq bit
;  cbi ControlPort, INTREQ

;SetInt_End:
  ret


; -----------------------------------------------------------------------------------
;
; Writes out the data in IOData to the Data port

OutputIOData:
  ; Set the data ports for output
  ser Scratch
  out DataPortDirection, Scratch

  ; Write out the response
  out DataPort, IOData

  ret

; -----------------------------------------------------------------------------------
; Clears and floats the Data port, deactivates WAIT and returns from the interrupt.

ClearDataPortAndReturn:
  ldi Scratch, 0
  out DataPortDirection, Scratch
  out DataPort, Scratch

  ; Turn off the /WAIT line
  sbi ControlPort, BUS_WAIT

  ; Clear the OutputData status flag
  cbr StatusRegister, 1 << OutputData

  reti

; -----------------------------------------------------------------------------------
; Select's the requested IRQ with the highest priority
;
; Input:
; Param0 IRQ Bitmap to test
;
; Returns:
; Param0 IRQ Vector
; Param1 IRQ Mask

SelectIRQ:
;  push r12
;  clr Param1
;
;  ldi YH, HIGH(VectorTable)
;  ldi YL, LOW(VectorTable)
;
;  ldi Scratch, 0x01

;IRQLoop:
;  mov r12, Param0

  ; if the bit is set, break out of the loop
;  and r12, Scratch
;  brnz IRQFound

;  inc YL

  ; shift the mask
;  lsl Scratch

  ; if we still have a value, loop
;  brnz IRQLoop

;IRQFound:
;  ld Param0, Y
;  mov Param1, Scratch

;  pop r12
  ret


; -----------------------------------------------------------------------------------
; Finds the in service IRQ with the highest priority
;
; Returns:
; Param1 IRQ Mask

FindActiveInterrupt:
;  push r12
;  ldi Scratch, 0x01
;
;ActiveLoop:
;  mov r12, ISR
;
;  ; if the bit is set, break out of the loop
;  and r12, Scratch
;  brnz ActiveFound
;
;  ; shift the mask
;  lsl Scratch
;
;  ; if we still have a value, loop
;  brnz ActiveLoop
;
;ActiveFound:
;  mov Param1, Scratch

;  pop r12
  ret


; -----------------------------------------------------------------------------------
;
; Soft reset the device
;

SoftReset:
  ; Set up the watch dog timer to go off and force a reset.
  wdr

  lds Scratch, WDTCSR
  ori Scratch, (1<<WDCE) | (1<<WDE)
  sts WDTCSR, Scratch

  ldi Scratch, (1<<WDE)
  sts WDTCSR, Scratch

ResetLoop:
  rjmp ResetLoop

; ===================================================================================
;    SRAM
; ===================================================================================

.dseg
.org SRAM_START

VectorRegister: .byte 1
AutoEOIRegister: .byte 1
VectorTable: .byte 8
BadVector: .byte 1






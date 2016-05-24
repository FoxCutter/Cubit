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
; /CS     | 04 PD2     PC2 25 | IRQ2
; /INTACK | 05 PD3     PC1 24 | IRQ1
; /INTREQ | 06 PD4     PC0 23 | IRQ0
; +5v     | 07 GND     GND 22 | GND
; GND     | 08 VCC     PC7 21 | IRQ7
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
; /CS: Chip Select, IN
; RD/WD: 1: Read, 0: Write, IN
; /WAIT: Set to low when the MCU is Reading/Writing the databus, OUT
; /INTREQ: Output line, goes low when the MCU wants to deliver an interrupt, OUT
; /INTACK: Sent from the CPU when it's time to write out the vector data to the bus, IN
;
; Future plans: 
;  * Set High/Low Active on INTACK, INTREQ and IRQx
;  * Set Level/Edge triggered on IRQx 
;  * Support a 'lock' INTACK pulse to lock the Vector to deliver (8086/8 need this)
;  * Automatic End of Interrupt
;  * Multi byte vectors (Allowing 8080 style 'jmp address' opcode vectors) (10yyxxxx yy = Byte Number, xxxx = irq number)
;  * Polling mode, (/INTREQ fires, but the next Read of the ISR is treated as the /IntAck)
;  * Cascading Interrupts (Master IRQx <-- Slave /IntReq, Master IRQx ---> Slave /IntAck)?
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
; Command     : *7: End of Interrupt 
; Register ID : Register to edit
; Data        : Register data
;
; Register     (ID)
; Master       (00) : *0: Enable Interrupts
; Configure:   (01) : *7: Automatic EOI              --- Not Yet Implemented
;                   : *6: INTACK lock/x86 Mode       --- Not Yet Implemented
;                   : *5: IRQREQ Low/High            --- Not Yet Implemented
;                   : *4: INTACK Low/High            --- Not Yet Implemented
;                   : *3: IRQx Low/High              --- Not Yet Implemented
;                   : *0: IRQ Trigger: (0) Edge Triggered, (1) Level Triggered   --- Not Yet Implemented
; IRR          (02) : *7-*0 IRQx has (1) Requested service (0) Not requested service. Read Only
; Vectors      (03) : *3: (0) Vector Range, (1) Individual Vectors
;                     *0-*2: Vector Skip value, when Bit 3 is 0, this value (+1) is used to build the vector table
; IRQx Vector  (8x) : Vector for given IRQ, if Vectors[3] is 0, this is the base vector all the other vectors are built on.
;                   : When Vectors[3] is 0 you can still read from all registers to get the current vector
; Spurious Int (8F) : Vector to give in the case of a Spurious Interrupt
; Soft Reset   (FF) : Writing any value to this register resets the chip
;
; Reset Values:
;  IRQ0 = 0x80
;  IRQ1 = 0x81
;  IRQ2 = 0x82
;  IRQ3 = 0x83
;  IRQ4 = 0x84
;  IRQ5 = 0x85
;  IRQ6 = 0x86
;  IRQ7 = 0x87
;  Spurious Int = 0xF0
;  All other registers are set to 0x00
;
; * One of the IRQx lines goes low, latching it's IRR bit
; * If the IMR bit is set, and interrupts are on, the INTREQ line is pulled low.
; * When the INTACK line goes low, the chip writes the vector of the highest priority IRQ in the IRR 
;   it then clears the bit in the IRR and sets it in the ISR.
; * ISR bit stays set until the EOI command is received. This does not prevent higher priority interrupts from becoming
;   Active
;
; Notes for cascading interrupts...
; With the lack of free pins on the DIP Tiny48, we don't have a huge number of options on how to 
;  cascade them together.
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
.def ZH = r31
.def ZL = r30

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

; Branch if Zero
.macro brez
   breq @0
.endmacro

; Branch if not Zero
.macro brnz
   brne @0
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

;.equ IRQ0 = PORTC0 
;.equ IRQ1 = PORTC1
;.equ IRQ2 = PORTC2
;.equ IRQ3 = PORTC3
;.equ IRQ4 = PORTC4
;.equ IRQ5 = PORTC5
.equ IRQ6 = PORTD6      ; On port D insted of C
;.equ IRQ7 = PORTC7

; Data port bits
.equ ADDRESS_MASK   = (1 << PORTD0) | (1 << PORTD1)
;.equ A0             = PORTD0
;.equ A1             = PORTD1
.equ CHIPSELECT     = PORTD2
.equ INTACK         = PORTD3
.equ INTREQ         = PORTD4
.equ BUS_WAIT       = PORTD5
.equ READ_WRITE     = PORTD7

; Master Register bits
.equ MasterInterruptEnable = 0

; Config Register bits (Not Implemented)
;.equ IRQ_Level             = 0
;.equ IRQ_Trigger           = 3
;.equ INTACT_Trigger        = 4
;.equ INTREQ_Trigger        = 5
;.equ INTACK_Lock           = 6
;.equ Auto_EOI              = 7

; Vector Register Bits
.equ VectorSkipMask    = 0x07
;.equ VectorSkip0       = 0
;.equ VectorSkip1       = 1
;.equ VectorSkip2       = 2
.equ IndividualVectors = 3

; Control Inputs
.equ EndOfInterrupt    = 7

; Register IDs
.equ RegisterMaster      = 0x00
.equ RegisterConfig      = 0x01
.equ RegisterIRR         = 0x02
.equ RegisterVectors     = 0x03
.equ RegisterDebug       = 0x42
.equ RegisterVectorBase  = 0x80
.equ RegisterSpuriousInt = 0x8F
.equ RegisterSoftReset   = 0xFF

; Globals 
.def ZeroReg            = r0
.def Scratch            = r16
.def MasterRegister     = r21
.def ConfigureRegister  = r22
.def ISR                = r23
.def IRR                = r24
.def IMR                = r25

; Function Parameters
.def Param0             = r14
.def Param1             = r15

.cseg
.org $0000
  rjmp Reset         ; RESET
  rjmp ChipSelectInt ; INT0
  rjmp IntAckInt     ; INT1
  reti               ; PCINT0
  rjmp IRQChangeInt  ; PCINT1
  rjmp IRQChangeInt  ; PCINT2
  reti;              ; PCINT3
  reti;              ; WDT
  reti;              ; TIMER1_CAPT
  reti;              ; TIMER1_COMPA
  reti;              ; TIMER1_COMPB
  reti;              ; TIMER1_OVF
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
  ; init stack pointer at the top of RAM
  ldi Scratch, LOW(RAMEND) 
  out SPL, Scratch

  ldi Scratch, HIGH(RAMEND) 
  out SPH, Scratch
  
  clr ZeroReg

  ; Clear any watch dog that might have reset us
  wdr
  ldi Scratch, 0x18
  sts WDTCSR, Scratch
  sts WDTCSR, r0
  

  ; Clear out the Registers
  clr ISR
  clr IRR
  clr IMR
  clr ConfigureRegister
  clr MasterRegister
  sts VectorRegister, Scratch
  sts RegisterID, Scratch

  ; Build the default int vectors
  ldi Scratch, 0x80 ; Base Vector
  mov Param0, Scratch
  
  ldi Scratch, 1 ; Skip Value
  mov Param1, Scratch

  rcall SetVectors

  ldi Scratch, 0xF0
  sts BadVector, Scratch

  ; Configure the ports
  ; Port B - Data In/Out, so leave it floating
  clr Scratch
  out DataPortDirection, Scratch
  out DataPort, Scratch
  
  ; Port C - IRQ In, with the pull up resisters
  out IRQPortDirection, Scratch  
  ;ldi Scratch, 0xBF
  out IRQPort, Scratch

  ; Port D - Control 
  ldi Scratch, (1 << INTREQ) | (1 << BUS_WAIT) ; INTREQ and BUS_WAIT are output pins
  out ControlPortDirection, Scratch
  ldi Scratch, 0x70 ; Pull up on IRQ6, and set INTREQ and BUS_WAIT High
  out ControlPort, Scratch                     

  ; Enable PinChange Interrupt 1 & 2
  ldi Scratch, 0x06;
  sts PCICR, Scratch

  ; PCINT1 for PortsC0-C7 (excluding C6)
  ldi Scratch, 0xBF
  sts PCMSK1, Scratch

  ; PCINT2 for PortD6 only
  ldi Scratch, 1 << IRQ6
  sts PCMSK2, Scratch

  ; Set both INT0 and INT1 to trigger on a Logic Change
  ldi Scratch, 0x05; 
  sts EICRA, Scratch
  
  ; Enable Int0 and Int1
  ldi Scratch, 0x03;
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

; -----------------------------------------------------------------------------------

IRQChangeInt:
  ; < Param0 = Active IRQs
  rcall GetIRQData

  ; Save the old Request register
  mov r9, IRR

  ; Latch the changed IRQ lines
  or IRR, Param0

  ; Pull out the bits that changed (IRR xor OldIRR)
  mov Param0, IRR 
  eor Param0, r9
  
  ; And fire the ints that have changed.
  ; > Param0 = Bitmap of IRQs that have gone active
  rcall SetIntReqAsNeeded 

  reti
  
; -----------------------------------------------------------------------------------

IntAckInt:
  in r10, ControlPortPins
  
  ; If IntAck is high, clear the data port and be done
  ebrs r10, INTACK
     rjmp CleaDataPortAndReturn

  ; Turn off the Int request line
  sbi ControlPort, INTREQ

  ; Turn on the /WAIT line
  cbi ControlPort, BUS_WAIT  

  ; if nothing is set, write out BadVector
  cpi IRR, 0
  breq IA_Spuriouse

  ; Find the highest priority interupt in the IRR
  ; > Param0 = IRR Bitmap
  ; < Param0 = Vector
  ; < Param1 = Bitmask
  mov Param0, IRR
  rcall SelectIRQ

  ; Set the bit in ISR
  or ISR, Param1
  
  ; clear bit in IRR
  com Param1
  and IRR, Param1
  
  rjmp IA_Complete

IA_Spuriouse:
  lds Param0, BadVector

IA_Complete:  
  ; Write out the response
  rcall OutputDataPort
  
  ; We will clear the port when Int line goes high  

  ; Turn off the /WAIT line
  sbi ControlPort, BUS_WAIT  

  reti
  
; -----------------------------------------------------------------------------------

ChipSelectInt:
  in r10, ControlPortPins

  ; If CHIPSELECT is high, clear the data port and be done
  ebrs r10, CHIPSELECT
    rjmp CleaDataPortAndReturn

  ; Turn on the /WAIT line
  cbi ControlPort, BUS_WAIT

  ; If READ/WRITE is clear, read the data from the port
  ebrc r10, READ_WRITE
    in r11, DataPortPins

  ; Pull out the address lines
  mov Scratch, r10
  andi Scratch, ADDRESS_MASK

  cpi Scratch, 0b00
  breq CE_ISR
  
  cpi Scratch, 0b01
  breq CE_IMR
  
  cpi Scratch, 0b10
  breq CE_Register
  
  cpi Scratch, 0b11
  breq CE_Data
  
;-------------- 00 --------------

CE_ISR:
  ; if Read/Write is clear we handle a command
  ebrc r10, READ_WRITE
    rjmp CE_Command

  ; Otherwise retun the ISR
  ebrs r10, READ_WRITE
    mov Param0, ISR

  rjmp CS_Complete

CE_Command:
  ; If EOI is clear, just get out of here
  ebrc r11, EndOfInterrupt
    rjmp CS_Complete

  ; Find the IRQ to clear, the mask is in Param1
  ; < Param1 = Maks of highest priority active IRQ
  rcall FindActiveInterrupt  

  ; Clear it out of the ISR
  com Param1 
  and ISR, Param1

  ; Get the state fo the IRQ lines
  ; < Param0 = Active IRQs
  rcall GetIRQData

  ; Latch the changed IRQ lines
  or IRR, Param0
  
  ; Fire an int for anything that's pending that's not blocked by a higher prority int.
  mov Param0, IRR

  ; > Param0 = Bitmap of IRQs that have gone active
  rcall SetIntReqAsNeeded 

  rjmp CS_Complete

;-------------- 01 --------------

CE_IMR:
  ; if Read/Write is clear we save the value
  ebrc r10, READ_WRITE
    mov IMR, r11

  ; if Read/Write is set we return the value
  ebrs r10, READ_WRITE
    mov Param0, IMR

  rjmp CS_Complete

;-------------- 10 --------------

CE_Register:
  ; if Read/Write is clear we save the value
  ebrc r10, READ_WRITE
    sts RegisterID, r11

  ; if Read/Write is set we return the value
  ebrs r10, READ_WRITE
    lds Param0, RegisterID

  rjmp CS_Complete

;-------------- 11 --------------

CE_Data:
  ldi YH, HIGH(VectorTable)
  ldi YL, LOW(VectorTable)
  
  lds Scratch, RegisterID
  
  cpi Scratch, RegisterMaster
  breq Data_Master

  cpi Scratch, RegisterConfig
  breq Data_Config

  cpi Scratch, RegisterIRR
  breq Data_IRR

  cpi Scratch, RegisterVectors
  breq Data_Vectors

  cpi Scratch, RegisterSpuriousInt
  breq Data_SpuriousInt
  
  cpi Scratch, RegisterSoftReset
  breq Data_SoftReset

  cpi Scratch, RegisterVectorBase
  breq Data_VectorBase
  brge Data_VectorDirect
  
  rjmp CS_Complete

; ------------------------------

Data_Master:
  ; if Read/Write is clear we save the value
  ebrc r10, READ_WRITE
    mov MasterRegister, r11
    
  ; if Read/Write is set we return the value
  ebrs r10, READ_WRITE
    mov Param0, MasterRegister

  rjmp CS_Complete


Data_Config:
  ; if Read/Write is clear we save the value
  ebrc r10, READ_WRITE
    mov ConfigureRegister, r11

  ; if Read/Write is set we return the value
  ebrs r10, READ_WRITE
    mov Param0, ConfigureRegister


Data_IRR:    
  ; if Read/Write is set we return the value
  ebrs r10, READ_WRITE
    mov Param0, IRR

  rjmp CS_Complete


Data_Vectors:
  ; if Read/Write is clear we save the value
  ebrc r10, READ_WRITE
    sts VectorRegister, r11

  ; if Read/Write is set we return the value
  ebrs r10, READ_WRITE
    lds Param0, VectorRegister

  rjmp CS_Complete


Data_SpuriousInt:
  ; if Read/Write is clear we save the value
  ebrc r10, READ_WRITE
    sts BadVector, r11

  ; if Read/Write is set we return the value
  ebrs r10, READ_WRITE
    lds Param0, BadVector
    
    rjmp CS_Complete

Data_VectorBase:
  ; if Read/Write is set we return the value
  ebrs r10, READ_WRITE
    ld Param0, Y
  ebrs r10, READ_WRITE
    rjmp CS_Complete

  lds r12, VectorRegister
  
  ; If they are doing individual vectors, just jump to that code
  ebrs r12, IndividualVectors
    rjmp Data_VectorDirect

  mov Param0, r11 ; Base Vector
  
  mov Scratch, r12
  andi Scratch, VectorSkipMask
  mov Param1, Scratch
  inc Param1

  rcall SetVectors
  
  rjmp CS_Complete

Data_VectorDirect:
  subi Scratch, RegisterVectorBase
  
  ; Make sure the value is 0-7
  cpi Scratch, 8
  brsh CS_Complete

  add YL, Scratch

  ; if Read/Write is clear we save the value
  ebrc r10, READ_WRITE
    st Y, r11

  ; if Read/Write is set we return the value
  ebrs r10, READ_WRITE
    ld Param0, Y

  rjmp CS_Complete

Data_SoftReset:
  rjmp SoftReset

; ----------------------------------------
CS_Complete:  
  ; If READ/WRITE is clear (We read from the port), we don't have to do anything else
  ebrc r10, READ_WRITE
     rjmp CS_Exit

  ; Write out the response in Param0
  rcall OutputDataPort


CS_Exit:
  ; Turn off the /WAIT line
  sbi ControlPort, BUS_WAIT  

  reti


; ===================================================================================
;    Utility Functions
; ===================================================================================

; -----------------------------------------------------------------------------------
; Loads the state of the IRQ pins
;
; GetIRQData ();
; Param0 = Bitmap of active IRQs

GetIRQData:
  ; Read IRQs from Ports
  in Param0, IRQPortPins
  in Scratch, ControlPortPins

  ; Make sure IRQ6 is moved over as well
  bst Scratch, IRQ6
  bld Param0, IRQ6

  ; Flip the IRQs so high is active, not low
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
  ebrc MasterRegister, MasterInterruptEnable 
     ret

  ; And it against the mask to find out which ones can even fire, if it's 0
  ; just end
  and Param0, IMR
  brez SetInt_End

  ; If nothing is in services just fire off the int.
  cpi ISR, 0
  breq SetInt_Fire
  
  ; Find the next IRQ to call based on the active int
  rcall SelectIRQ
  
  ; If ISP >= Param1 (the mask of the highest pending IRQ) don't fire.
  cp ISR, Param1
  brsh SetInt_End

SetInt_Fire:
  ; Okay, we have something to fire, so clear the IntReq bit
  cbi ControlPort, INTREQ

SetInt_End: 
  ret
  
; -----------------------------------------------------------------------------------
;
; Writes to the data part
; 
; OutputDataPort(Data)
; Param0 = Data

OutputDataPort:
  ; Set the data ports for output
  ser Scratch
  out DataPortDirection, Scratch
  
  ; Write out the response
  out DataPort, Param0  

  ret
  
; -----------------------------------------------------------------------------------
;
; Clears the data port (Sets back to tri-state) and returns from the interupt.
;

CleaDataPortAndReturn:
  ldi Scratch, 0
  out DataPortDirection, Scratch
  out DataPort, Scratch
  
  ; Turn off the /WAIT line
  sbi ControlPort, BUS_WAIT
  
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
  push r12
  clr Param1
  
  ldi YH, HIGH(VectorTable)
  ldi YL, LOW(VectorTable)

  ldi Scratch, 0x01

IRQLoop:  
  mov r12, Param0

  ; if the bit is set, break out of the loop
  and r12, Scratch
  brnz IRQFound

  inc YL

  ; shift the mask
  lsl Scratch

  ; if we still have a value, loop
  brnz IRQLoop

IRQFound:  
  ld Param0, Y
  mov Param1, Scratch  

  pop r12
  ret
  
; -----------------------------------------------------------------------------------  
; Finds the in service IRQ with the highest priority
;
; Returns:
; Param1 IRQ Mask

FindActiveInterrupt:
  push r12
  ldi Scratch, 0x01

ActiveLoop:  
  mov r12, ISR

  ; if the bit is set, break out of the loop
  and r12, Scratch
  brnz ActiveFound

  ; shift the mask
  lsl Scratch

  ; if we still have a value, loop
  brnz ActiveLoop

ActiveFound:  
  mov Param1, Scratch  

  pop r12
  ret
  
  
; -----------------------------------------------------------------------------------
; 
; Soft reset the device
;

SoftReset:
  ; Set up the watch dog timer to go off and force a reset.
  clr Scratch
  out MCUSR, Scratch

  ldi Scratch, 0x18
  sts WDTCSR, Scratch

  ldi Scratch, 0x08
  sts WDTCSR, Scratch
  
ResetLoop:  
  rjmp ResetLoop


; ===================================================================================
;    SRAM
; ===================================================================================

.dseg
.org SRAM_START

RegisterID: .byte 1
VectorRegister: .byte 1
VectorTable: .byte 8
BadVector: .byte 1


  



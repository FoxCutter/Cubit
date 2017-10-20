# Microcontroller Tools

This folder holds the source code for the custom microcontroller tools used by the cubit project.

They are written for the ATtiny48 Micro Controller, and the [gavrasm avr assembler](http://community.atmel.com/projects/gavrasm-avr-assembler) is used to build it.

Interrupt controller:
 
  Custom interrupt controller.

  **Command Line**: gavrasm.exe int.s

Dual 4-Bit Hex to 7 Segment Decoder
  
  A fairly simple kit to dislpay a byte as two hex value on a 7 segment display. Supports common Anode and Cathode depending on how the oHI/oLO pin is tied.
   
  **Command Line**: gavrasm.exe 7seghex.s

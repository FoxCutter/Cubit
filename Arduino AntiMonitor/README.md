# Arduino AntiMonitor

This [Arduino](https://www.arduino.cc/en/Main/Software) project works as a monitor program, but not one running on the native hardware. When connected to the z80 bus it can read and write memory, data parts, control the CPU execution and import and export standard Intel hex files. 

It's expecting to talk to three **74299 8-bit shift register** ICs, two that are chained together to support 16-bit output.
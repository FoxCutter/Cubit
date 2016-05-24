// Three pins for the address bit shifter. There will be two
// chained together to handle a full 16 bit address.
#define AddressInput 2
#define AddressOutput 3
#define AddressClock 4
#define AddressDisplay 5
#define AddressMode 6

// Data pins, a bit more complicated as we want to support reading.
#define DataInput 8
#define DataOutput 9
#define DataClock 10
#define DataDisplay 11
#define DataMode 12

// Status pins (unused)
#define StatusInput A5
#define StatusOutput A4
#define StatusClock A3
#define StatusDisplay A2
#define StatusMode A1

#define StatusIQRQ 		0x01 // 0
#define StatusMEMRQ		0x04 // 2
#define StatusRD		0x10 // 4
#define StatusWD		0x40 // 6

#define StatusINT 		0x02 // 1
#define StatusNMI		0x08 // 3
#define StatusHalt		0x20 // 5
#define StatusM1		0x80 // 7

// And the memory pins.
#define DataWrite A5
#define DataRead A4
#define MemoryRequest A3
#define IORequest A2
#define BusReq A1
#define BusAck A0

// System pins

#define M1Input 7
#define BusWait 13


// Three pins for the address bit shifter. There will be two
// chained together to handle a full 16 bit address.
#define AddressInput 11
#define AddressOutput 10
#define AddressClock 9
#define AddressDisplay 8
#define AddressMode 7

// Data pins
#define DataInput 6
#define DataOutput 5
#define DataClock 4
#define DataDisplay 3
#define DataMode 2

// And the memory pins.
#define DataWrite A0
#define DataRead A1
#define MemoryRequest A2
#define IORequest A3

// System pins
#define M1Input 12
#define BusReq A4
#define BusAck A5
#define BusWait 13


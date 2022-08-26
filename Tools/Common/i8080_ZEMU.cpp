namespace z80
{
    OpcodeEntry MainOpcodes[0x100] =
    {
		{ L"NOP", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0, }, // 00: NOP
		{ L"LXI", Function::LOAD, Addressing::WordReg_BC, Addressing::ImmediateWord, 10, 0, 0, }, // 01nnnn: LXI B, nnnn
		{ L"STAX", Function::LOAD, Addressing::WordReg_BCRef, Addressing::ByteReg_A, 7, 0, 0, }, // 02: STAX B, |A
		{ L"INX", Function::INC, Addressing::WordReg_BC, Addressing::None, 5, 0, 0, }, // 03: INX B
		{ L"INR", Function::INC, Addressing::ByteReg_B, Addressing::None, 5, 0, 0, }, // 04: INR B
		{ L"DCR", Function::DEC, Addressing::ByteReg_B, Addressing::None, 5, 0, 0, }, // 05: DCR B
		{ L"MVI", Function::LOAD, Addressing::ByteReg_B, Addressing::ImmediateByte, 7, 0, 0, }, // 06nn: MVI B, nn
		{ L"RLC", Function::RL, Addressing::ByteReg_A, Addressing::None, 4, 0, 0, }, // 07: RLC |A
		{ L"NOP", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0, }, // 08: NOP
		{ L"DAD", Function::ADD, Addressing::WordReg_HL, Addressing::WordReg_BC, 10, 0, 0, }, // 09: DAD |H, B
		{ L"LDAX", Function::LOAD, Addressing::ByteReg_A, Addressing::WordReg_BCRef, 7, 0, 0, }, // 0A: LDAX |A, B
		{ L"DCX", Function::DEC, Addressing::WordReg_BC, Addressing::None, 5, 0, 0, }, // 0B: DCX B
		{ L"INR", Function::INC, Addressing::ByteReg_C, Addressing::None, 5, 0, 0, }, // 0C: INR C
		{ L"DCR", Function::DEC, Addressing::ByteReg_C, Addressing::None, 5, 0, 0, }, // 0D: DCR C
		{ L"MVI", Function::LOAD, Addressing::ByteReg_C, Addressing::ImmediateByte, 7, 0, 0, }, // 0Enn: MVI C, nn
		{ L"RRC", Function::RR, Addressing::ByteReg_A, Addressing::None, 4, 0, 0, }, // 0F: RRC |A
		{ L"NOP", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0, }, // 10: NOP
		{ L"LXI", Function::LOAD, Addressing::WordReg_DE, Addressing::ImmediateWord, 10, 0, 0, }, // 11nnnn: LXI D, nnnn
		{ L"STAX", Function::LOAD, Addressing::WordReg_DERef, Addressing::ByteReg_A, 7, 0, 0, }, // 12: STAX D, |A
		{ L"INX", Function::INC, Addressing::WordReg_DE, Addressing::None, 5, 0, 0, }, // 13: INX D
		{ L"INR", Function::INC, Addressing::ByteReg_D, Addressing::None, 5, 0, 0, }, // 14: INR D
		{ L"DCR", Function::DEC, Addressing::ByteReg_D, Addressing::None, 5, 0, 0, }, // 15: DCR D
		{ L"MVI", Function::LOAD, Addressing::ByteReg_D, Addressing::ImmediateByte, 7, 0, 0, }, // 16nn: MVI D, nn
		{ L"RAL", Function::RL_CY, Addressing::ByteReg_A, Addressing::None, 4, 0, 0, }, // 17: RAL |A
		{ L"NOP", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0, }, // 18: NOP
		{ L"DAD", Function::ADD, Addressing::WordReg_HL, Addressing::WordReg_DE, 10, 0, 0, }, // 19: DAD |H, D
		{ L"LDAX", Function::LOAD, Addressing::ByteReg_A, Addressing::WordReg_DERef, 7, 0, 0, }, // 1A: LDAX |A, D
		{ L"DCX", Function::DEC, Addressing::WordReg_DE, Addressing::None, 5, 0, 0, }, // 1B: DCX D
		{ L"INR", Function::INC, Addressing::ByteReg_E, Addressing::None, 5, 0, 0, }, // 1C: INR E
		{ L"DCR", Function::DEC, Addressing::ByteReg_E, Addressing::None, 5, 0, 0, }, // 1D: DCR E
		{ L"MVI", Function::LOAD, Addressing::ByteReg_E, Addressing::ImmediateByte, 7, 0, 0, }, // 1Enn: MVI E, nn
		{ L"RAR", Function::RR_CY, Addressing::ByteReg_A, Addressing::None, 4, 0, 0, }, // 1F: RAR |A
		{ L"NOP", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0, }, // 20: NOP
		{ L"LXI", Function::LOAD, Addressing::WordReg_HL, Addressing::ImmediateWord, 10, 0, 0, }, // 21nnnn: LXI H, nnnn
		{ L"SHLD", Function::LOAD, Addressing::AddressWordRef, Addressing::WordReg_HL, 16, 0, 0, }, // 22nnnn: SHLD nnnn, |H
		{ L"INX", Function::INC, Addressing::WordReg_HL, Addressing::None, 5, 0, 0, }, // 23: INX H
		{ L"INR", Function::INC, Addressing::ByteReg_H, Addressing::None, 5, 0, 0, }, // 24: INR H
		{ L"DCR", Function::DEC, Addressing::ByteReg_H, Addressing::None, 5, 0, 0, }, // 25: DCR H
		{ L"MVI", Function::LOAD, Addressing::ByteReg_H, Addressing::ImmediateByte, 7, 0, 0, }, // 26nn: MVI H, nn
		{ L"DAA", Function::BCD_ADJUST, Addressing::ByteReg_A, Addressing::None, 4, 0, 0, }, // 27: DAA |A
		{ L"NOP", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0, }, // 28: NOP
		{ L"DAD", Function::ADD, Addressing::WordReg_HL, Addressing::WordReg_HL, 10, 0, 0, }, // 29: DAD |H, H
		{ L"LHLD", Function::LOAD, Addressing::WordReg_HL, Addressing::AddressWordRef, 16, 0, 0, }, // 2Annnn: LHLD |H, nnnn
		{ L"DCX", Function::DEC, Addressing::WordReg_HL, Addressing::None, 5, 0, 0, }, // 2B: DCX H
		{ L"INR", Function::INC, Addressing::ByteReg_L, Addressing::None, 5, 0, 0, }, // 2C: INR L
		{ L"DCR", Function::DEC, Addressing::ByteReg_L, Addressing::None, 5, 0, 0, }, // 2D: DCR L
		{ L"MVI", Function::LOAD, Addressing::ByteReg_L, Addressing::ImmediateByte, 7, 0, 0, }, // 2Enn: MVI L, nn
		{ L"CMA", Function::NOT, Addressing::ByteReg_A, Addressing::None, 4, 0, 0, }, // 2F: CMA |A
		{ L"NOP", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0, }, // 30: NOP
		{ L"LXI", Function::LOAD, Addressing::WordReg_SP, Addressing::ImmediateWord, 10, 0, 0, }, // 31nnnn: LXI SP, nnnn
		{ L"STA", Function::LOAD, Addressing::AddressByteRef, Addressing::ByteReg_A, 13, 0, 0, }, // 32nnnn: STA nnnn, |A
		{ L"INX", Function::INC, Addressing::WordReg_SP, Addressing::None, 5, 0, 0, }, // 33: INX SP
		{ L"INR", Function::INC, Addressing::ByteReg_M, Addressing::None, 10, 0, 0, }, // 34: INR M
		{ L"DCR", Function::DEC, Addressing::ByteReg_M, Addressing::None, 10, 0, 0, }, // 35: DCR M
		{ L"MVI", Function::LOAD, Addressing::ByteReg_M, Addressing::ImmediateByte, 10, 0, 0, }, // 36nn: MVI M, nn
		{ L"STC", Function::CY_SET, Addressing::None, Addressing::None, 4, 0, 0, }, // 37: STC
		{ L"NOP", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0, }, // 38: NOP
		{ L"DAD", Function::ADD, Addressing::WordReg_HL, Addressing::WordReg_SP, 10, 0, 0, }, // 39: DAD |H, SP
		{ L"LDA", Function::LOAD, Addressing::ByteReg_A, Addressing::AddressByteRef, 13, 0, 0, }, // 3Annnn: LDA |A, nnnn
		{ L"DCX", Function::DEC, Addressing::WordReg_SP, Addressing::None, 5, 0, 0, }, // 3B: DCX SP
		{ L"INR", Function::INC, Addressing::ByteReg_A, Addressing::None, 5, 0, 0, }, // 3C: INR A
		{ L"DCR", Function::DEC, Addressing::ByteReg_A, Addressing::None, 5, 0, 0, }, // 3D: DCR A
		{ L"MVI", Function::LOAD, Addressing::ByteReg_A, Addressing::ImmediateByte, 7, 0, 0, }, // 3Enn: MVI A, nn
		{ L"CMC", Function::CY_INVERT, Addressing::None, Addressing::None, 4, 0, 0, }, // 3F: CMC
		{ L"MOV", Function::LOAD, Addressing::ByteReg_B, Addressing::ByteReg_B, 5, 0, 0, }, // 40: MOV B, B
		{ L"MOV", Function::LOAD, Addressing::ByteReg_B, Addressing::ByteReg_C, 5, 0, 0, }, // 41: MOV B, C
		{ L"MOV", Function::LOAD, Addressing::ByteReg_B, Addressing::ByteReg_D, 5, 0, 0, }, // 42: MOV B, D
		{ L"MOV", Function::LOAD, Addressing::ByteReg_B, Addressing::ByteReg_E, 5, 0, 0, }, // 43: MOV B, E
		{ L"MOV", Function::LOAD, Addressing::ByteReg_B, Addressing::ByteReg_H, 5, 0, 0, }, // 44: MOV B, H
		{ L"MOV", Function::LOAD, Addressing::ByteReg_B, Addressing::ByteReg_L, 5, 0, 0, }, // 45: MOV B, L
		{ L"MOV", Function::LOAD, Addressing::ByteReg_B, Addressing::ByteReg_M, 7, 0, 0, }, // 46: MOV B, M
		{ L"MOV", Function::LOAD, Addressing::ByteReg_B, Addressing::ByteReg_A, 5, 0, 0, }, // 47: MOV B, A
		{ L"MOV", Function::LOAD, Addressing::ByteReg_C, Addressing::ByteReg_B, 5, 0, 0, }, // 48: MOV C, B
		{ L"MOV", Function::LOAD, Addressing::ByteReg_C, Addressing::ByteReg_C, 5, 0, 0, }, // 49: MOV C, C
		{ L"MOV", Function::LOAD, Addressing::ByteReg_C, Addressing::ByteReg_D, 5, 0, 0, }, // 4A: MOV C, D
		{ L"MOV", Function::LOAD, Addressing::ByteReg_C, Addressing::ByteReg_E, 5, 0, 0, }, // 4B: MOV C, E
		{ L"MOV", Function::LOAD, Addressing::ByteReg_C, Addressing::ByteReg_H, 5, 0, 0, }, // 4C: MOV C, H
		{ L"MOV", Function::LOAD, Addressing::ByteReg_C, Addressing::ByteReg_L, 5, 0, 0, }, // 4D: MOV C, L
		{ L"MOV", Function::LOAD, Addressing::ByteReg_C, Addressing::ByteReg_M, 7, 0, 0, }, // 4E: MOV C, M
		{ L"MOV", Function::LOAD, Addressing::ByteReg_C, Addressing::ByteReg_A, 5, 0, 0, }, // 4F: MOV C, A
		{ L"MOV", Function::LOAD, Addressing::ByteReg_D, Addressing::ByteReg_B, 5, 0, 0, }, // 50: MOV D, B
		{ L"MOV", Function::LOAD, Addressing::ByteReg_D, Addressing::ByteReg_C, 5, 0, 0, }, // 51: MOV D, C
		{ L"MOV", Function::LOAD, Addressing::ByteReg_D, Addressing::ByteReg_D, 5, 0, 0, }, // 52: MOV D, D
		{ L"MOV", Function::LOAD, Addressing::ByteReg_D, Addressing::ByteReg_E, 5, 0, 0, }, // 53: MOV D, E
		{ L"MOV", Function::LOAD, Addressing::ByteReg_D, Addressing::ByteReg_H, 5, 0, 0, }, // 54: MOV D, H
		{ L"MOV", Function::LOAD, Addressing::ByteReg_D, Addressing::ByteReg_L, 5, 0, 0, }, // 55: MOV D, L
		{ L"MOV", Function::LOAD, Addressing::ByteReg_D, Addressing::ByteReg_M, 7, 0, 0, }, // 56: MOV D, M
		{ L"MOV", Function::LOAD, Addressing::ByteReg_D, Addressing::ByteReg_A, 5, 0, 0, }, // 57: MOV D, A
		{ L"MOV", Function::LOAD, Addressing::ByteReg_E, Addressing::ByteReg_B, 5, 0, 0, }, // 58: MOV E, B
		{ L"MOV", Function::LOAD, Addressing::ByteReg_E, Addressing::ByteReg_C, 5, 0, 0, }, // 59: MOV E, C
		{ L"MOV", Function::LOAD, Addressing::ByteReg_E, Addressing::ByteReg_D, 5, 0, 0, }, // 5A: MOV E, D
		{ L"MOV", Function::LOAD, Addressing::ByteReg_E, Addressing::ByteReg_E, 5, 0, 0, }, // 5B: MOV E, E
		{ L"MOV", Function::LOAD, Addressing::ByteReg_E, Addressing::ByteReg_H, 5, 0, 0, }, // 5C: MOV E, H
		{ L"MOV", Function::LOAD, Addressing::ByteReg_E, Addressing::ByteReg_L, 5, 0, 0, }, // 5D: MOV E, L
		{ L"MOV", Function::LOAD, Addressing::ByteReg_E, Addressing::ByteReg_M, 7, 0, 0, }, // 5E: MOV E, M
		{ L"MOV", Function::LOAD, Addressing::ByteReg_E, Addressing::ByteReg_A, 5, 0, 0, }, // 5F: MOV E, A
		{ L"MOV", Function::LOAD, Addressing::ByteReg_H, Addressing::ByteReg_B, 5, 0, 0, }, // 60: MOV H, B
		{ L"MOV", Function::LOAD, Addressing::ByteReg_H, Addressing::ByteReg_C, 5, 0, 0, }, // 61: MOV H, C
		{ L"MOV", Function::LOAD, Addressing::ByteReg_H, Addressing::ByteReg_D, 5, 0, 0, }, // 62: MOV H, D
		{ L"MOV", Function::LOAD, Addressing::ByteReg_H, Addressing::ByteReg_E, 5, 0, 0, }, // 63: MOV H, E
		{ L"MOV", Function::LOAD, Addressing::ByteReg_H, Addressing::ByteReg_H, 5, 0, 0, }, // 64: MOV H, H
		{ L"MOV", Function::LOAD, Addressing::ByteReg_H, Addressing::ByteReg_L, 5, 0, 0, }, // 65: MOV H, L
		{ L"MOV", Function::LOAD, Addressing::ByteReg_H, Addressing::ByteReg_M, 7, 0, 0, }, // 66: MOV H, M
		{ L"MOV", Function::LOAD, Addressing::ByteReg_H, Addressing::ByteReg_A, 5, 0, 0, }, // 67: MOV H, A
		{ L"MOV", Function::LOAD, Addressing::ByteReg_L, Addressing::ByteReg_B, 5, 0, 0, }, // 68: MOV L, B
		{ L"MOV", Function::LOAD, Addressing::ByteReg_L, Addressing::ByteReg_C, 5, 0, 0, }, // 69: MOV L, C
		{ L"MOV", Function::LOAD, Addressing::ByteReg_L, Addressing::ByteReg_D, 5, 0, 0, }, // 6A: MOV L, D
		{ L"MOV", Function::LOAD, Addressing::ByteReg_L, Addressing::ByteReg_E, 5, 0, 0, }, // 6B: MOV L, E
		{ L"MOV", Function::LOAD, Addressing::ByteReg_L, Addressing::ByteReg_H, 5, 0, 0, }, // 6C: MOV L, H
		{ L"MOV", Function::LOAD, Addressing::ByteReg_L, Addressing::ByteReg_L, 5, 0, 0, }, // 6D: MOV L, L
		{ L"MOV", Function::LOAD, Addressing::ByteReg_L, Addressing::ByteReg_M, 7, 0, 0, }, // 6E: MOV L, M
		{ L"MOV", Function::LOAD, Addressing::ByteReg_L, Addressing::ByteReg_A, 5, 0, 0, }, // 6F: MOV L, A
		{ L"MOV", Function::LOAD, Addressing::ByteReg_M, Addressing::ByteReg_B, 7, 0, 0, }, // 70: MOV M, B
		{ L"MOV", Function::LOAD, Addressing::ByteReg_M, Addressing::ByteReg_C, 7, 0, 0, }, // 71: MOV M, C
		{ L"MOV", Function::LOAD, Addressing::ByteReg_M, Addressing::ByteReg_D, 7, 0, 0, }, // 72: MOV M, D
		{ L"MOV", Function::LOAD, Addressing::ByteReg_M, Addressing::ByteReg_E, 7, 0, 0, }, // 73: MOV M, E
		{ L"MOV", Function::LOAD, Addressing::ByteReg_M, Addressing::ByteReg_H, 7, 0, 0, }, // 74: MOV M, H
		{ L"MOV", Function::LOAD, Addressing::ByteReg_M, Addressing::ByteReg_L, 7, 0, 0, }, // 75: MOV M, L
		{ L"HLT", Function::HALT, Addressing::None, Addressing::None, 7, 0, 0, }, // 76: HLT
		{ L"MOV", Function::LOAD, Addressing::ByteReg_M, Addressing::ByteReg_A, 7, 0, 0, }, // 77: MOV M, A
		{ L"MOV", Function::LOAD, Addressing::ByteReg_A, Addressing::ByteReg_B, 5, 0, 0, }, // 78: MOV A, B
		{ L"MOV", Function::LOAD, Addressing::ByteReg_A, Addressing::ByteReg_C, 5, 0, 0, }, // 79: MOV A, C
		{ L"MOV", Function::LOAD, Addressing::ByteReg_A, Addressing::ByteReg_D, 5, 0, 0, }, // 7A: MOV A, D
		{ L"MOV", Function::LOAD, Addressing::ByteReg_A, Addressing::ByteReg_E, 5, 0, 0, }, // 7B: MOV A, E
		{ L"MOV", Function::LOAD, Addressing::ByteReg_A, Addressing::ByteReg_H, 5, 0, 0, }, // 7C: MOV A, H
		{ L"MOV", Function::LOAD, Addressing::ByteReg_A, Addressing::ByteReg_L, 5, 0, 0, }, // 7D: MOV A, L
		{ L"MOV", Function::LOAD, Addressing::ByteReg_A, Addressing::ByteReg_M, 7, 0, 0, }, // 7E: MOV A, M
		{ L"MOV", Function::LOAD, Addressing::ByteReg_A, Addressing::ByteReg_A, 5, 0, 0, }, // 7F: MOV A, A
		{ L"ADD", Function::ADD, Addressing::ByteReg_A, Addressing::ByteReg_B, 4, 0, 0, }, // 80: ADD |A, B
		{ L"ADD", Function::ADD, Addressing::ByteReg_A, Addressing::ByteReg_C, 4, 0, 0, }, // 81: ADD |A, C
		{ L"ADD", Function::ADD, Addressing::ByteReg_A, Addressing::ByteReg_D, 4, 0, 0, }, // 82: ADD |A, D
		{ L"ADD", Function::ADD, Addressing::ByteReg_A, Addressing::ByteReg_E, 4, 0, 0, }, // 83: ADD |A, E
		{ L"ADD", Function::ADD, Addressing::ByteReg_A, Addressing::ByteReg_H, 4, 0, 0, }, // 84: ADD |A, H
		{ L"ADD", Function::ADD, Addressing::ByteReg_A, Addressing::ByteReg_L, 4, 0, 0, }, // 85: ADD |A, L
		{ L"ADD", Function::ADD, Addressing::ByteReg_A, Addressing::ByteReg_M, 7, 0, 0, }, // 86: ADD |A, M
		{ L"ADD", Function::ADD, Addressing::ByteReg_A, Addressing::ByteReg_A, 4, 0, 0, }, // 87: ADD |A, A
		{ L"ADC", Function::ADD_CY, Addressing::ByteReg_A, Addressing::ByteReg_B, 4, 0, 0, }, // 88: ADC |A, B
		{ L"ADC", Function::ADD_CY, Addressing::ByteReg_A, Addressing::ByteReg_C, 4, 0, 0, }, // 89: ADC |A, C
		{ L"ADC", Function::ADD_CY, Addressing::ByteReg_A, Addressing::ByteReg_D, 4, 0, 0, }, // 8A: ADC |A, D
		{ L"ADC", Function::ADD_CY, Addressing::ByteReg_A, Addressing::ByteReg_E, 4, 0, 0, }, // 8B: ADC |A, E
		{ L"ADC", Function::ADD_CY, Addressing::ByteReg_A, Addressing::ByteReg_H, 4, 0, 0, }, // 8C: ADC |A, H
		{ L"ADC", Function::ADD_CY, Addressing::ByteReg_A, Addressing::ByteReg_L, 4, 0, 0, }, // 8D: ADC |A, L
		{ L"ADC", Function::ADD_CY, Addressing::ByteReg_A, Addressing::ByteReg_M, 7, 0, 0, }, // 8E: ADC |A, M
		{ L"ADC", Function::ADD_CY, Addressing::ByteReg_A, Addressing::ByteReg_A, 4, 0, 0, }, // 8F: ADC |A, A
		{ L"SUB", Function::SUB, Addressing::ByteReg_A, Addressing::ByteReg_B, 4, 0, 0, }, // 90: SUB |A, B
		{ L"SUB", Function::SUB, Addressing::ByteReg_A, Addressing::ByteReg_C, 4, 0, 0, }, // 91: SUB |A, C
		{ L"SUB", Function::SUB, Addressing::ByteReg_A, Addressing::ByteReg_D, 4, 0, 0, }, // 92: SUB |A, D
		{ L"SUB", Function::SUB, Addressing::ByteReg_A, Addressing::ByteReg_E, 4, 0, 0, }, // 93: SUB |A, E
		{ L"SUB", Function::SUB, Addressing::ByteReg_A, Addressing::ByteReg_H, 4, 0, 0, }, // 94: SUB |A, H
		{ L"SUB", Function::SUB, Addressing::ByteReg_A, Addressing::ByteReg_L, 4, 0, 0, }, // 95: SUB |A, L
		{ L"SUB", Function::SUB, Addressing::ByteReg_A, Addressing::ByteReg_M, 7, 0, 0, }, // 96: SUB |A, M
		{ L"SUB", Function::SUB, Addressing::ByteReg_A, Addressing::ByteReg_A, 4, 0, 0, }, // 97: SUB |A, A
		{ L"SBB", Function::SUB_CY, Addressing::ByteReg_A, Addressing::ByteReg_B, 4, 0, 0, }, // 98: SBB |A, B
		{ L"SBB", Function::SUB_CY, Addressing::ByteReg_A, Addressing::ByteReg_C, 4, 0, 0, }, // 99: SBB |A, C
		{ L"SBB", Function::SUB_CY, Addressing::ByteReg_A, Addressing::ByteReg_D, 4, 0, 0, }, // 9A: SBB |A, D
		{ L"SBB", Function::SUB_CY, Addressing::ByteReg_A, Addressing::ByteReg_E, 4, 0, 0, }, // 9B: SBB |A, E
		{ L"SBB", Function::SUB_CY, Addressing::ByteReg_A, Addressing::ByteReg_H, 4, 0, 0, }, // 9C: SBB |A, H
		{ L"SBB", Function::SUB_CY, Addressing::ByteReg_A, Addressing::ByteReg_L, 4, 0, 0, }, // 9D: SBB |A, L
		{ L"SBB", Function::SUB_CY, Addressing::ByteReg_A, Addressing::ByteReg_M, 7, 0, 0, }, // 9E: SBB |A, M
		{ L"SBB", Function::SUB_CY, Addressing::ByteReg_A, Addressing::ByteReg_A, 4, 0, 0, }, // 9F: SBB |A, A
		{ L"ANA", Function::AND, Addressing::ByteReg_A, Addressing::ByteReg_B, 4, 0, 0, }, // A0: ANA |A, B
		{ L"ANA", Function::AND, Addressing::ByteReg_A, Addressing::ByteReg_C, 4, 0, 0, }, // A1: ANA |A, C
		{ L"ANA", Function::AND, Addressing::ByteReg_A, Addressing::ByteReg_D, 4, 0, 0, }, // A2: ANA |A, D
		{ L"ANA", Function::AND, Addressing::ByteReg_A, Addressing::ByteReg_E, 4, 0, 0, }, // A3: ANA |A, E
		{ L"ANA", Function::AND, Addressing::ByteReg_A, Addressing::ByteReg_H, 4, 0, 0, }, // A4: ANA |A, H
		{ L"ANA", Function::AND, Addressing::ByteReg_A, Addressing::ByteReg_L, 4, 0, 0, }, // A5: ANA |A, L
		{ L"ANA", Function::AND, Addressing::ByteReg_A, Addressing::ByteReg_M, 7, 0, 0, }, // A6: ANA |A, M
		{ L"ANA", Function::AND, Addressing::ByteReg_A, Addressing::ByteReg_A, 4, 0, 0, }, // A7: ANA |A, A
		{ L"XRA", Function::XOR, Addressing::ByteReg_A, Addressing::ByteReg_B, 4, 0, 0, }, // A8: XRA |A, B
		{ L"XRA", Function::XOR, Addressing::ByteReg_A, Addressing::ByteReg_C, 4, 0, 0, }, // A9: XRA |A, C
		{ L"XRA", Function::XOR, Addressing::ByteReg_A, Addressing::ByteReg_D, 4, 0, 0, }, // AA: XRA |A, D
		{ L"XRA", Function::XOR, Addressing::ByteReg_A, Addressing::ByteReg_E, 4, 0, 0, }, // AB: XRA |A, E
		{ L"XRA", Function::XOR, Addressing::ByteReg_A, Addressing::ByteReg_H, 4, 0, 0, }, // AC: XRA |A, H
		{ L"XRA", Function::XOR, Addressing::ByteReg_A, Addressing::ByteReg_L, 4, 0, 0, }, // AD: XRA |A, L
		{ L"XRA", Function::XOR, Addressing::ByteReg_A, Addressing::ByteReg_M, 7, 0, 0, }, // AE: XRA |A, M
		{ L"XRA", Function::XOR, Addressing::ByteReg_A, Addressing::ByteReg_A, 4, 0, 0, }, // AF: XRA |A, A
		{ L"ORA", Function::OR, Addressing::ByteReg_A, Addressing::ByteReg_B, 4, 0, 0, }, // B0: ORA |A, B
		{ L"ORA", Function::OR, Addressing::ByteReg_A, Addressing::ByteReg_C, 4, 0, 0, }, // B1: ORA |A, C
		{ L"ORA", Function::OR, Addressing::ByteReg_A, Addressing::ByteReg_D, 4, 0, 0, }, // B2: ORA |A, D
		{ L"ORA", Function::OR, Addressing::ByteReg_A, Addressing::ByteReg_E, 4, 0, 0, }, // B3: ORA |A, E
		{ L"ORA", Function::OR, Addressing::ByteReg_A, Addressing::ByteReg_H, 4, 0, 0, }, // B4: ORA |A, H
		{ L"ORA", Function::OR, Addressing::ByteReg_A, Addressing::ByteReg_L, 4, 0, 0, }, // B5: ORA |A, L
		{ L"ORA", Function::OR, Addressing::ByteReg_A, Addressing::ByteReg_M, 7, 0, 0, }, // B6: ORA |A, M
		{ L"ORA", Function::OR, Addressing::ByteReg_A, Addressing::ByteReg_A, 4, 0, 0, }, // B7: ORA |A, A
		{ L"CMP", Function::CMP, Addressing::ByteReg_A, Addressing::ByteReg_B, 4, 0, 0, }, // B8: CMP |A, B
		{ L"CMP", Function::CMP, Addressing::ByteReg_A, Addressing::ByteReg_C, 4, 0, 0, }, // B9: CMP |A, C
		{ L"CMP", Function::CMP, Addressing::ByteReg_A, Addressing::ByteReg_D, 4, 0, 0, }, // BA: CMP |A, D
		{ L"CMP", Function::CMP, Addressing::ByteReg_A, Addressing::ByteReg_E, 4, 0, 0, }, // BB: CMP |A, E
		{ L"CMP", Function::CMP, Addressing::ByteReg_A, Addressing::ByteReg_H, 4, 0, 0, }, // BC: CMP |A, H
		{ L"CMP", Function::CMP, Addressing::ByteReg_A, Addressing::ByteReg_L, 4, 0, 0, }, // BD: CMP |A, L
		{ L"CMP", Function::CMP, Addressing::ByteReg_A, Addressing::ByteReg_M, 7, 0, 0, }, // BE: CMP |A, M
		{ L"CMP", Function::CMP, Addressing::ByteReg_A, Addressing::ByteReg_A, 4, 0, 0, }, // BF: CMP |A, A
		{ L"RNZ", Function::RET, Addressing::#Flag_NZ, Addressing::None, 5, 11, 0, }, // C0: RNZ |NZ
		{ L"POP", Function::POP, Addressing::WordReg_BC, Addressing::None, 10, 0, 0, }, // C1: POP B
		{ L"JNZ", Function::JMP, Addressing::#Flag_NZ, Addressing::Address, 10, 10, 0, }, // C2nnnn: JNZ |NZ, nnnn
		{ L"JMP", Function::JMP, Addressing::Address, Addressing::None, 10, 0, 0, }, // C3nnnn: JMP nnnn
		{ L"CNZ", Function::CALL, Addressing::#Flag_NZ, Addressing::Address, 10, 17, 0, }, // C4nnnn: CNZ |NZ, nnnn
		{ L"PUSH", Function::PUSH, Addressing::WordReg_BC, Addressing::None, 11, 0, 0, }, // C5: PUSH B
		{ L"ADI", Function::ADD, Addressing::ByteReg_A, Addressing::ImmediateByte, 7, 0, 0, }, // C6nn: ADI |A, nn
		{ L"RST", Function::RST, Addressing::Value0, Addressing::None, 11, 0, 0, }, // C7: RST 0
		{ L"RZ", Function::RET, Addressing::#Flag_Z, Addressing::None, 5, 11, 0, }, // C8: RZ |Z
		{ L"RET", Function::RET, Addressing::None, Addressing::None, 10, 0, 0, }, // C9: RET
		{ L"JZ", Function::JMP, Addressing::#Flag_Z, Addressing::Address, 10, 10, 0, }, // CAnnnn: JZ |Z, nnnn
		{ L"JMP", Function::JMP, Addressing::Address, Addressing::None, 10, 10, 0, }, // CBnnnn: JMP nnnn
		{ L"CZ", Function::CALL, Addressing::#Flag_Z, Addressing::Address, 10, 17, 0, }, // CCnnnn: CZ |Z, nnnn
		{ L"CALL", Function::CALL, Addressing::Address, Addressing::None, 17, 0, 0, }, // CDnnnn: CALL nnnn
		{ L"ACI", Function::ADD_CY, Addressing::ByteReg_A, Addressing::ImmediateByte, 7, 0, 0, }, // CEnn: ACI |A, nn
		{ L"RST", Function::RST, Addressing::Value1, Addressing::None, 11, 0, 0, }, // CF: RST 1
		{ L"RNC", Function::RET, Addressing::#Flag_NC, Addressing::None, 5, 11, 0, }, // D0: RNC |NC
		{ L"POP", Function::POP, Addressing::WordReg_DE, Addressing::None, 10, 0, 0, }, // D1: POP D
		{ L"JNC", Function::JMP, Addressing::#Flag_NC, Addressing::Address, 10, 10, 0, }, // D2nnnn: JNC |NC, nnnn
		{ L"OUT", Function::OUT, Addressing::ImmediateByte, Addressing::ByteReg_A, 10, 10, 0, }, // D3nn: OUT nn, |A
		{ L"CNC", Function::CALL, Addressing::#Flag_NC, Addressing::Address, 10, 17, 0, }, // D4nnnn: CNC |NC, nnnn
		{ L"PUSH", Function::PUSH, Addressing::WordReg_DE, Addressing::None, 11, 0, 0, }, // D5: PUSH D
		{ L"SUI", Function::SUB, Addressing::ByteReg_A, Addressing::ImmediateByte, 7, 0, 0, }, // D6nn: SUI |A, nn
		{ L"RST", Function::RST, Addressing::Value2, Addressing::None, 11, 0, 0, }, // D7: RST 2
		{ L"RC", Function::RET, Addressing::#Flag_CY, Addressing::None, 5, 11, 0, }, // D8: RC |CY
		{ L"RET", Function::RET, Addressing::None, Addressing::None, 10, 0, 0, }, // D9: RET
		{ L"JC", Function::JMP, Addressing::#Flag_CY, Addressing::Address, 10, 10, 0, }, // DAnnnn: JC |CY, nnnn
		{ L"IN", Function::IN, Addressing::ByteReg_A, Addressing::ImmediateByte, 10, 10, 0, }, // DBnn: IN |A, nn
		{ L"CC", Function::CALL, Addressing::#Flag_CY, Addressing::Address, 10, 17, 0, }, // DCnnnn: CC |CY, nnnn
		{ L"CALL", Function::CALL, Addressing::Address, Addressing::None, 17, 0, 0, }, // DDnnnn: CALL nnnn
		{ L"SBI", Function::SUB_CY, Addressing::ByteReg_A, Addressing::ImmediateByte, 7, 0, 0, }, // DEnn: SBI |A, nn
		{ L"RST", Function::RST, Addressing::Value3, Addressing::None, 11, 0, 0, }, // DF: RST 3
		{ L"RPO", Function::RET, Addressing::#Flag_PO, Addressing::None, 5, 11, 0, }, // E0: RPO |PO
		{ L"POP", Function::POP, Addressing::WordReg_HL, Addressing::None, 10, 0, 0, }, // E1: POP H
		{ L"JPO", Function::JMP, Addressing::#Flag_PO, Addressing::Address, 10, 10, 0, }, // E2nnnn: JPO |PO, nnnn
		{ L"XTHL", Function::EX, Addressing::WordReg_SPRef, Addressing::WordReg_HL, 18, 0, 0, }, // E3: XTHL |(SP), |H
		{ L"CPO", Function::CALL, Addressing::#Flag_PO, Addressing::Address, 10, 17, 0, }, // E4nnnn: CPO |PO, nnnn
		{ L"PUSH", Function::PUSH, Addressing::WordReg_HL, Addressing::None, 11, 0, 0, }, // E5: PUSH H
		{ L"ANI", Function::AND, Addressing::ByteReg_A, Addressing::ImmediateByte, 7, 0, 0, }, // E6nn: ANI |A, nn
		{ L"RST", Function::RST, Addressing::Value4, Addressing::None, 11, 0, 0, }, // E7: RST 4
		{ L"RPE", Function::RET, Addressing::#Flag_PE, Addressing::None, 5, 11, 0, }, // E8: RPE |PE
		{ L"PCHL", Function::JMP, Addressing::WordReg_HL, Addressing::None, 5, 0, 0, }, // E9: PCHL |H
		{ L"JPE", Function::JMP, Addressing::#Flag_PE, Addressing::Address, 10, 10, 0, }, // EAnnnn: JPE |PE, nnnn
		{ L"XCHG", Function::EX, Addressing::WordReg_DE, Addressing::WordReg_HL, 4, 0, 0, }, // EB: XCHG |D, |H
		{ L"CPE", Function::CALL, Addressing::#Flag_PE, Addressing::Address, 10, 17, 0, }, // ECnnnn: CPE |PE, nnnn
		{ L"CALL", Function::CALL, Addressing::Address, Addressing::None, 17, 0, 0, }, // EDnnnn: CALL nnnn
		{ L"XRI", Function::XOR, Addressing::ByteReg_A, Addressing::ImmediateByte, 7, 0, 0, }, // EEnn: XRI |A, nn
		{ L"RST", Function::RST, Addressing::Value5, Addressing::None, 11, 0, 0, }, // EF: RST 5
		{ L"RP", Function::RET, Addressing::#Flag_P, Addressing::None, 5, 11, 0, }, // F0: RP |P
		{ L"POP", Function::POP, Addressing::WordReg_PSW, Addressing::None, 10, 0, 0, }, // F1: POP PSW
		{ L"JP", Function::JMP, Addressing::#Flag_P, Addressing::Address, 10, 10, 0, }, // F2nnnn: JP |P, nnnn
		{ L"DI", Function::DI, Addressing::None, Addressing::None, 4, 0, 0, }, // F3: DI
		{ L"CP", Function::CALL, Addressing::#Flag_P, Addressing::Address, 10, 17, 0, }, // F4nnnn: CP |P, nnnn
		{ L"PUSH", Function::PUSH, Addressing::WordReg_PSW, Addressing::None, 11, 0, 0, }, // F5: PUSH PSW
		{ L"ORI", Function::OR, Addressing::ByteReg_A, Addressing::ImmediateByte, 7, 0, 0, }, // F6nn: ORI |A, nn
		{ L"RST", Function::RST, Addressing::Value6, Addressing::None, 11, 0, 0, }, // F7: RST 6
		{ L"RM", Function::RET, Addressing::#Flag_M, Addressing::None, 5, 11, 0, }, // F8: RM |M
		{ L"SPHL", Function::LOAD, Addressing::WordReg_SP, Addressing::WordReg_HL, 5, 0, 0, }, // F9: SPHL |SP, |H
		{ L"JM", Function::JMP, Addressing::#Flag_M, Addressing::Address, 10, 10, 0, }, // FAnnnn: JM |M, nnnn
		{ L"EI", Function::EI, Addressing::None, Addressing::None, 4, 0, 0, }, // FB: EI
		{ L"CM", Function::CALL, Addressing::#Flag_M, Addressing::Address, 10, 17, 0, }, // FCnnnn: CM |M, nnnn
		{ L"CALL", Function::CALL, Addressing::Address, Addressing::None, 17, 0, 0, }, // FDnnnn: CALL nnnn
		{ L"CPI", Function::CMP, Addressing::ByteReg_A, Addressing::ImmediateByte, 7, 0, 0, }, // FEnn: CPI |A, nn
		{ L"RST", Function::RST, Addressing::Value7, Addressing::None, 11, 0, 0, }, // FF: RST 7
    };

    OpcodeEntry ExtenededOpcodes[0x100] =
    {
    };

    OpcodeEntry BitOpcodes[0x100] =
    {
    };
}

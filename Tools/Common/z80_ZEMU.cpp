namespace z80
{
    OpcodeEntry MainOpcodes[0x100] =
    {
		{ L"NOP", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0, }, // 00: NOP
		{ L"LD", Function::LOAD, Addressing::WordReg_BC, Addressing::ImmediateWord, 10, 0, 0, }, // 01nnnn: LD BC, nnnn
		{ L"LD", Function::LOAD, Addressing::WordReg_BCRef, Addressing::ByteReg_A, 7, 0, 0, }, // 02: LD (BC), A
		{ L"INC", Function::INC, Addressing::WordReg_BC, Addressing::None, 6, 0, 0, }, // 03: INC BC
		{ L"INC", Function::INC, Addressing::ByteReg_B, Addressing::None, 4, 0, 0, }, // 04: INC B
		{ L"DEC", Function::DEC, Addressing::ByteReg_B, Addressing::None, 4, 0, 0, }, // 05: DEC B
		{ L"LD", Function::LOAD, Addressing::ByteReg_B, Addressing::ImmediateByte, 7, 0, 0, }, // 06nn: LD B, nn
		{ L"RLCA", Function::RL, Addressing::ByteReg_A, Addressing::None, 4, 0, 0, }, // 07: RLCA |A
		{ L"EX", Function::EX, Addressing::WordReg_AF, Addressing::WordReg_AF_Alt, 4, 0, 0, }, // 08: EX AF, AF'
		{ L"ADD", Function::ADD, Addressing::WordReg_HL, Addressing::WordReg_BC, 11, 0, 15, }, // 09: ADD HL, BC
		{ L"LD", Function::LOAD, Addressing::ByteReg_A, Addressing::WordReg_BCRef, 7, 0, 0, }, // 0A: LD A, (BC)
		{ L"DEC", Function::DEC, Addressing::WordReg_BC, Addressing::None, 6, 0, 0, }, // 0B: DEC BC
		{ L"INC", Function::INC, Addressing::ByteReg_C, Addressing::None, 4, 0, 0, }, // 0C: INC C
		{ L"DEC", Function::DEC, Addressing::ByteReg_C, Addressing::None, 4, 0, 0, }, // 0D: DEC C
		{ L"LD", Function::LOAD, Addressing::ByteReg_C, Addressing::ImmediateByte, 7, 0, 0, }, // 0Enn: LD C, nn
		{ L"RRCA", Function::RR, Addressing::ByteReg_A, Addressing::None, 4, 0, 0, }, // 0F: RRCA |A
		{ L"DJNZ", Function::DJNZ, Addressing::Displacement, Addressing::None, 8, 13, 0, }, // 10nn: DJNZ e-2
		{ L"LD", Function::LOAD, Addressing::WordReg_DE, Addressing::ImmediateWord, 10, 0, 0, }, // 11nnnn: LD DE, nnnn
		{ L"LD", Function::LOAD, Addressing::WordReg_DERef, Addressing::ByteReg_A, 7, 0, 0, }, // 12: LD (DE), A
		{ L"INC", Function::INC, Addressing::WordReg_DE, Addressing::None, 6, 0, 0, }, // 13: INC DE
		{ L"INC", Function::INC, Addressing::ByteReg_D, Addressing::None, 4, 0, 0, }, // 14: INC D
		{ L"DEC", Function::DEC, Addressing::ByteReg_D, Addressing::None, 4, 0, 0, }, // 15: DEC D
		{ L"LD", Function::LOAD, Addressing::ByteReg_D, Addressing::ImmediateByte, 7, 0, 0, }, // 16nn: LD D, nn
		{ L"RLA", Function::RL_CY, Addressing::ByteReg_A, Addressing::None, 4, 0, 0, }, // 17: RLA |A
		{ L"JR", Function::JMPR, Addressing::Displacement, Addressing::None, 12, 0, 0, }, // 18nn: JR e-2
		{ L"ADD", Function::ADD, Addressing::WordReg_HL, Addressing::WordReg_DE, 11, 0, 15, }, // 19: ADD HL, DE
		{ L"LD", Function::LOAD, Addressing::ByteReg_A, Addressing::WordReg_DERef, 7, 0, 0, }, // 1A: LD A, (DE)
		{ L"DEC", Function::DEC, Addressing::WordReg_DE, Addressing::None, 6, 0, 0, }, // 1B: DEC DE
		{ L"INC", Function::INC, Addressing::ByteReg_E, Addressing::None, 4, 0, 0, }, // 1C: INC E
		{ L"DEC", Function::DEC, Addressing::ByteReg_E, Addressing::None, 4, 0, 0, }, // 1D: DEC E
		{ L"LD", Function::LOAD, Addressing::ByteReg_E, Addressing::ImmediateByte, 7, 0, 0, }, // 1Enn: LD E, nn
		{ L"RRA", Function::RR_CY, Addressing::ByteReg_A, Addressing::None, 4, 0, 0, }, // 1F: RRA |A
		{ L"JR", Function::JMPR, Addressing::Flag_NZ, Addressing::Displacement, 7, 12, 0, }, // 20nn: JR NZ, e-2
		{ L"LD", Function::LOAD, Addressing::WordReg_HL, Addressing::ImmediateWord, 10, 0, 14, }, // 21nnnn: LD HL, nnnn
		{ L"LD", Function::LOAD, Addressing::AddressWordRef, Addressing::WordReg_HL, 16, 0, 20, }, // 22nnnn: LD (nnnn), HL
		{ L"INC", Function::INC, Addressing::WordReg_HL, Addressing::None, 6, 0, 10, }, // 23: INC HL
		{ L"INC", Function::INC, Addressing::ByteReg_H, Addressing::None, 4, 0, 8, }, // 24: INC H
		{ L"DEC", Function::DEC, Addressing::ByteReg_H, Addressing::None, 4, 0, 8, }, // 25: DEC H
		{ L"LD", Function::LOAD, Addressing::ByteReg_H, Addressing::ImmediateByte, 7, 0, 11, }, // 26nn: LD H, nn
		{ L"DAA", Function::BCD_ADJUST, Addressing::ByteReg_A, Addressing::None, 4, 0, 0, }, // 27: DAA |A
		{ L"JR", Function::JMPR, Addressing::Flag_Z, Addressing::Displacement, 7, 12, 0, }, // 28nn: JR Z, e-2
		{ L"ADD", Function::ADD, Addressing::WordReg_HL, Addressing::WordReg_HL, 11, 0, 15, }, // 29: ADD HL, HL
		{ L"LD", Function::LOAD, Addressing::WordReg_HL, Addressing::AddressWordRef, 16, 0, 20, }, // 2Annnn: LD HL, (nnnn)
		{ L"DEC", Function::DEC, Addressing::WordReg_HL, Addressing::None, 6, 0, 10, }, // 2B: DEC HL
		{ L"INC", Function::INC, Addressing::ByteReg_L, Addressing::None, 4, 0, 8, }, // 2C: INC L
		{ L"DEC", Function::DEC, Addressing::ByteReg_L, Addressing::None, 4, 0, 8, }, // 2D: DEC L
		{ L"LD", Function::LOAD, Addressing::ByteReg_L, Addressing::ImmediateByte, 7, 0, 11, }, // 2Enn: LD L, nn
		{ L"CPL", Function::NOT, Addressing::ByteReg_A, Addressing::None, 4, 0, 0, }, // 2F: CPL A
		{ L"JR", Function::JMPR, Addressing::Flag_NC, Addressing::Displacement, 7, 12, 0, }, // 30nn: JR NC, e-2
		{ L"LD", Function::LOAD, Addressing::WordReg_SP, Addressing::ImmediateWord, 10, 0, 0, }, // 31nnnn: LD SP, nnnn
		{ L"LD", Function::LOAD, Addressing::AddressByteRef, Addressing::ByteReg_A, 13, 0, 0, }, // 32nnnn: LD (nnnn), A
		{ L"INC", Function::INC, Addressing::WordReg_SP, Addressing::None, 6, 0, 0, }, // 33: INC SP
		{ L"INC", Function::INC, Addressing::WordReg_HLRef, Addressing::None, 11, 0, 23, }, // 34: INC (HL)
		{ L"DEC", Function::DEC, Addressing::WordReg_HLRef, Addressing::None, 11, 0, 23, }, // 35: DEC (HL)
		{ L"LD", Function::LOAD, Addressing::WordReg_HLRef, Addressing::ImmediateByte, 10, 0, 19, }, // 36nn: LD (HL), nn
		{ L"SCF", Function::CY_SET, Addressing::None, Addressing::None, 4, 0, 0, }, // 37: SCF
		{ L"JR", Function::JMPR, Addressing::Flag_CY, Addressing::Displacement, 7, 12, 0, }, // 38nn: JR CY, e-2
		{ L"ADD", Function::ADD, Addressing::WordReg_HL, Addressing::WordReg_SP, 11, 0, 15, }, // 39: ADD HL, SP
		{ L"LD", Function::LOAD, Addressing::ByteReg_A, Addressing::AddressByteRef, 13, 0, 0, }, // 3Annnn: LD A, (nnnn)
		{ L"DEC", Function::DEC, Addressing::WordReg_SP, Addressing::None, 6, 0, 0, }, // 3B: DEC SP
		{ L"INC", Function::INC, Addressing::ByteReg_A, Addressing::None, 4, 0, 0, }, // 3C: INC A
		{ L"DEC", Function::DEC, Addressing::ByteReg_A, Addressing::None, 4, 0, 0, }, // 3D: DEC A
		{ L"LD", Function::LOAD, Addressing::ByteReg_A, Addressing::ImmediateByte, 7, 0, 0, }, // 3Enn: LD A, nn
		{ L"CCF", Function::CY_INVERT, Addressing::None, Addressing::None, 4, 0, 0, }, // 3F: CCF
		{ L"LD", Function::LOAD, Addressing::ByteReg_B, Addressing::ByteReg_B, 4, 0, 0, }, // 40: LD B, B
		{ L"LD", Function::LOAD, Addressing::ByteReg_B, Addressing::ByteReg_C, 4, 0, 0, }, // 41: LD B, C
		{ L"LD", Function::LOAD, Addressing::ByteReg_B, Addressing::ByteReg_D, 4, 0, 0, }, // 42: LD B, D
		{ L"LD", Function::LOAD, Addressing::ByteReg_B, Addressing::ByteReg_E, 4, 0, 0, }, // 43: LD B, E
		{ L"LD", Function::LOAD, Addressing::ByteReg_B, Addressing::ByteReg_H, 4, 0, 8, }, // 44: LD B, H
		{ L"LD", Function::LOAD, Addressing::ByteReg_B, Addressing::ByteReg_L, 4, 0, 8, }, // 45: LD B, L
		{ L"LD", Function::LOAD, Addressing::ByteReg_B, Addressing::WordReg_HLRef, 7, 0, 19, }, // 46: LD B, (HL)
		{ L"LD", Function::LOAD, Addressing::ByteReg_B, Addressing::ByteReg_A, 4, 0, 0, }, // 47: LD B, A
		{ L"LD", Function::LOAD, Addressing::ByteReg_C, Addressing::ByteReg_B, 4, 0, 0, }, // 48: LD C, B
		{ L"LD", Function::LOAD, Addressing::ByteReg_C, Addressing::ByteReg_C, 4, 0, 0, }, // 49: LD C, C
		{ L"LD", Function::LOAD, Addressing::ByteReg_C, Addressing::ByteReg_D, 4, 0, 0, }, // 4A: LD C, D
		{ L"LD", Function::LOAD, Addressing::ByteReg_C, Addressing::ByteReg_E, 4, 0, 0, }, // 4B: LD C, E
		{ L"LD", Function::LOAD, Addressing::ByteReg_C, Addressing::ByteReg_H, 4, 0, 8, }, // 4C: LD C, H
		{ L"LD", Function::LOAD, Addressing::ByteReg_C, Addressing::ByteReg_L, 4, 0, 8, }, // 4D: LD C, L
		{ L"LD", Function::LOAD, Addressing::ByteReg_C, Addressing::WordReg_HLRef, 7, 0, 19, }, // 4E: LD C, (HL)
		{ L"LD", Function::LOAD, Addressing::ByteReg_C, Addressing::ByteReg_A, 4, 0, 0, }, // 4F: LD C, A
		{ L"LD", Function::LOAD, Addressing::ByteReg_D, Addressing::ByteReg_B, 4, 0, 0, }, // 50: LD D, B
		{ L"LD", Function::LOAD, Addressing::ByteReg_D, Addressing::ByteReg_C, 4, 0, 0, }, // 51: LD D, C
		{ L"LD", Function::LOAD, Addressing::ByteReg_D, Addressing::ByteReg_D, 4, 0, 0, }, // 52: LD D, D
		{ L"LD", Function::LOAD, Addressing::ByteReg_D, Addressing::ByteReg_E, 4, 0, 0, }, // 53: LD D, E
		{ L"LD", Function::LOAD, Addressing::ByteReg_D, Addressing::ByteReg_H, 4, 0, 8, }, // 54: LD D, H
		{ L"LD", Function::LOAD, Addressing::ByteReg_D, Addressing::ByteReg_L, 4, 0, 8, }, // 55: LD D, L
		{ L"LD", Function::LOAD, Addressing::ByteReg_D, Addressing::WordReg_HLRef, 7, 0, 19, }, // 56: LD D, (HL)
		{ L"LD", Function::LOAD, Addressing::ByteReg_D, Addressing::ByteReg_A, 4, 0, 0, }, // 57: LD D, A
		{ L"LD", Function::LOAD, Addressing::ByteReg_E, Addressing::ByteReg_B, 4, 0, 0, }, // 58: LD E, B
		{ L"LD", Function::LOAD, Addressing::ByteReg_E, Addressing::ByteReg_C, 4, 0, 0, }, // 59: LD E, C
		{ L"LD", Function::LOAD, Addressing::ByteReg_E, Addressing::ByteReg_D, 4, 0, 0, }, // 5A: LD E, D
		{ L"LD", Function::LOAD, Addressing::ByteReg_E, Addressing::ByteReg_E, 4, 0, 0, }, // 5B: LD E, E
		{ L"LD", Function::LOAD, Addressing::ByteReg_E, Addressing::ByteReg_H, 4, 0, 8, }, // 5C: LD E, H
		{ L"LD", Function::LOAD, Addressing::ByteReg_E, Addressing::ByteReg_L, 4, 0, 8, }, // 5D: LD E, L
		{ L"LD", Function::LOAD, Addressing::ByteReg_E, Addressing::WordReg_HLRef, 7, 0, 19, }, // 5E: LD E, (HL)
		{ L"LD", Function::LOAD, Addressing::ByteReg_E, Addressing::ByteReg_A, 4, 0, 0, }, // 5F: LD E, A
		{ L"LD", Function::LOAD, Addressing::ByteReg_H, Addressing::ByteReg_B, 4, 0, 8, }, // 60: LD H, B
		{ L"LD", Function::LOAD, Addressing::ByteReg_H, Addressing::ByteReg_C, 4, 0, 8, }, // 61: LD H, C
		{ L"LD", Function::LOAD, Addressing::ByteReg_H, Addressing::ByteReg_D, 4, 0, 8, }, // 62: LD H, D
		{ L"LD", Function::LOAD, Addressing::ByteReg_H, Addressing::ByteReg_E, 4, 0, 8, }, // 63: LD H, E
		{ L"LD", Function::LOAD, Addressing::ByteReg_H, Addressing::ByteReg_H, 4, 0, 8, }, // 64: LD H, H
		{ L"LD", Function::LOAD, Addressing::ByteReg_H, Addressing::ByteReg_L, 4, 0, 8, }, // 65: LD H, L
		{ L"LD", Function::LOAD, Addressing::ByteReg_H, Addressing::WordReg_HLRef, 7, 0, 19, }, // 66: LD H, (HL)
		{ L"LD", Function::LOAD, Addressing::ByteReg_H, Addressing::ByteReg_A, 4, 0, 8, }, // 67: LD H, A
		{ L"LD", Function::LOAD, Addressing::ByteReg_L, Addressing::ByteReg_B, 4, 0, 8, }, // 68: LD L, B
		{ L"LD", Function::LOAD, Addressing::ByteReg_L, Addressing::ByteReg_C, 4, 0, 8, }, // 69: LD L, C
		{ L"LD", Function::LOAD, Addressing::ByteReg_L, Addressing::ByteReg_D, 4, 0, 8, }, // 6A: LD L, D
		{ L"LD", Function::LOAD, Addressing::ByteReg_L, Addressing::ByteReg_E, 4, 0, 8, }, // 6B: LD L, E
		{ L"LD", Function::LOAD, Addressing::ByteReg_L, Addressing::ByteReg_H, 4, 0, 8, }, // 6C: LD L, H
		{ L"LD", Function::LOAD, Addressing::ByteReg_L, Addressing::ByteReg_L, 4, 0, 8, }, // 6D: LD L, L
		{ L"LD", Function::LOAD, Addressing::ByteReg_L, Addressing::WordReg_HLRef, 7, 0, 19, }, // 6E: LD L, (HL)
		{ L"LD", Function::LOAD, Addressing::ByteReg_L, Addressing::ByteReg_A, 4, 0, 8, }, // 6F: LD L, A
		{ L"LD", Function::LOAD, Addressing::WordReg_HLRef, Addressing::ByteReg_B, 7, 0, 19, }, // 70: LD (HL), B
		{ L"LD", Function::LOAD, Addressing::WordReg_HLRef, Addressing::ByteReg_C, 7, 0, 19, }, // 71: LD (HL), C
		{ L"LD", Function::LOAD, Addressing::WordReg_HLRef, Addressing::ByteReg_D, 7, 0, 19, }, // 72: LD (HL), D
		{ L"LD", Function::LOAD, Addressing::WordReg_HLRef, Addressing::ByteReg_E, 7, 0, 19, }, // 73: LD (HL), E
		{ L"LD", Function::LOAD, Addressing::WordReg_HLRef, Addressing::ByteReg_H, 7, 0, 19, }, // 74: LD (HL), H
		{ L"LD", Function::LOAD, Addressing::WordReg_HLRef, Addressing::ByteReg_L, 7, 0, 19, }, // 75: LD (HL), L
		{ L"HALT", Function::HALT, Addressing::None, Addressing::None, 4, 0, 0, }, // 76: HALT
		{ L"LD", Function::LOAD, Addressing::WordReg_HLRef, Addressing::ByteReg_A, 7, 0, 19, }, // 77: LD (HL), A
		{ L"LD", Function::LOAD, Addressing::ByteReg_A, Addressing::ByteReg_B, 4, 0, 0, }, // 78: LD A, B
		{ L"LD", Function::LOAD, Addressing::ByteReg_A, Addressing::ByteReg_C, 4, 0, 0, }, // 79: LD A, C
		{ L"LD", Function::LOAD, Addressing::ByteReg_A, Addressing::ByteReg_D, 4, 0, 0, }, // 7A: LD A, D
		{ L"LD", Function::LOAD, Addressing::ByteReg_A, Addressing::ByteReg_E, 4, 0, 0, }, // 7B: LD A, E
		{ L"LD", Function::LOAD, Addressing::ByteReg_A, Addressing::ByteReg_H, 4, 0, 8, }, // 7C: LD A, H
		{ L"LD", Function::LOAD, Addressing::ByteReg_A, Addressing::ByteReg_L, 4, 0, 8, }, // 7D: LD A, L
		{ L"LD", Function::LOAD, Addressing::ByteReg_A, Addressing::WordReg_HLRef, 7, 0, 19, }, // 7E: LD A, (HL)
		{ L"LD", Function::LOAD, Addressing::ByteReg_A, Addressing::ByteReg_A, 4, 0, 0, }, // 7F: LD A, A
		{ L"ADD", Function::ADD, Addressing::ByteReg_A, Addressing::ByteReg_B, 4, 0, 0, }, // 80: ADD A, B
		{ L"ADD", Function::ADD, Addressing::ByteReg_A, Addressing::ByteReg_C, 4, 0, 0, }, // 81: ADD A, C
		{ L"ADD", Function::ADD, Addressing::ByteReg_A, Addressing::ByteReg_D, 4, 0, 0, }, // 82: ADD A, D
		{ L"ADD", Function::ADD, Addressing::ByteReg_A, Addressing::ByteReg_E, 4, 0, 0, }, // 83: ADD A, E
		{ L"ADD", Function::ADD, Addressing::ByteReg_A, Addressing::ByteReg_H, 4, 0, 8, }, // 84: ADD A, H
		{ L"ADD", Function::ADD, Addressing::ByteReg_A, Addressing::ByteReg_L, 4, 0, 8, }, // 85: ADD A, L
		{ L"ADD", Function::ADD, Addressing::ByteReg_A, Addressing::WordReg_HLRef, 7, 0, 19, }, // 86: ADD A, (HL)
		{ L"ADD", Function::ADD, Addressing::ByteReg_A, Addressing::ByteReg_A, 4, 0, 0, }, // 87: ADD A, A
		{ L"ADC", Function::ADD_CY, Addressing::ByteReg_A, Addressing::ByteReg_B, 4, 0, 0, }, // 88: ADC A, B
		{ L"ADC", Function::ADD_CY, Addressing::ByteReg_A, Addressing::ByteReg_C, 4, 0, 0, }, // 89: ADC A, C
		{ L"ADC", Function::ADD_CY, Addressing::ByteReg_A, Addressing::ByteReg_D, 4, 0, 0, }, // 8A: ADC A, D
		{ L"ADC", Function::ADD_CY, Addressing::ByteReg_A, Addressing::ByteReg_E, 4, 0, 0, }, // 8B: ADC A, E
		{ L"ADC", Function::ADD_CY, Addressing::ByteReg_A, Addressing::ByteReg_H, 4, 0, 8, }, // 8C: ADC A, H
		{ L"ADC", Function::ADD_CY, Addressing::ByteReg_A, Addressing::ByteReg_L, 4, 0, 8, }, // 8D: ADC A, L
		{ L"ADC", Function::ADD_CY, Addressing::ByteReg_A, Addressing::WordReg_HLRef, 7, 0, 19, }, // 8E: ADC A, (HL)
		{ L"ADC", Function::ADD_CY, Addressing::ByteReg_A, Addressing::ByteReg_A, 4, 0, 0, }, // 8F: ADC A, A
		{ L"SUB", Function::SUB, Addressing::ByteReg_A, Addressing::ByteReg_B, 4, 0, 0, }, // 90: SUB A, B
		{ L"SUB", Function::SUB, Addressing::ByteReg_A, Addressing::ByteReg_C, 4, 0, 0, }, // 91: SUB A, C
		{ L"SUB", Function::SUB, Addressing::ByteReg_A, Addressing::ByteReg_D, 4, 0, 0, }, // 92: SUB A, D
		{ L"SUB", Function::SUB, Addressing::ByteReg_A, Addressing::ByteReg_E, 4, 0, 0, }, // 93: SUB A, E
		{ L"SUB", Function::SUB, Addressing::ByteReg_A, Addressing::ByteReg_H, 4, 0, 8, }, // 94: SUB A, H
		{ L"SUB", Function::SUB, Addressing::ByteReg_A, Addressing::ByteReg_L, 4, 0, 8, }, // 95: SUB A, L
		{ L"SUB", Function::SUB, Addressing::ByteReg_A, Addressing::WordReg_HLRef, 7, 0, 19, }, // 96: SUB A, (HL)
		{ L"SUB", Function::SUB, Addressing::ByteReg_A, Addressing::ByteReg_A, 4, 0, 0, }, // 97: SUB A, A
		{ L"SBC", Function::SUB_CY, Addressing::ByteReg_A, Addressing::ByteReg_B, 4, 0, 0, }, // 98: SBC A, B
		{ L"SBC", Function::SUB_CY, Addressing::ByteReg_A, Addressing::ByteReg_C, 4, 0, 0, }, // 99: SBC A, C
		{ L"SBC", Function::SUB_CY, Addressing::ByteReg_A, Addressing::ByteReg_D, 4, 0, 0, }, // 9A: SBC A, D
		{ L"SBC", Function::SUB_CY, Addressing::ByteReg_A, Addressing::ByteReg_E, 4, 0, 0, }, // 9B: SBC A, E
		{ L"SBC", Function::SUB_CY, Addressing::ByteReg_A, Addressing::ByteReg_H, 4, 0, 8, }, // 9C: SBC A, H
		{ L"SBC", Function::SUB_CY, Addressing::ByteReg_A, Addressing::ByteReg_L, 4, 0, 8, }, // 9D: SBC A, L
		{ L"SBC", Function::SUB_CY, Addressing::ByteReg_A, Addressing::WordReg_HLRef, 7, 0, 19, }, // 9E: SBC A, (HL)
		{ L"SBC", Function::SUB_CY, Addressing::ByteReg_A, Addressing::ByteReg_A, 4, 0, 0, }, // 9F: SBC A, A
		{ L"AND", Function::AND, Addressing::ByteReg_A, Addressing::ByteReg_B, 4, 0, 0, }, // A0: AND A, B
		{ L"AND", Function::AND, Addressing::ByteReg_A, Addressing::ByteReg_C, 4, 0, 0, }, // A1: AND A, C
		{ L"AND", Function::AND, Addressing::ByteReg_A, Addressing::ByteReg_D, 4, 0, 0, }, // A2: AND A, D
		{ L"AND", Function::AND, Addressing::ByteReg_A, Addressing::ByteReg_E, 4, 0, 0, }, // A3: AND A, E
		{ L"AND", Function::AND, Addressing::ByteReg_A, Addressing::ByteReg_H, 4, 0, 8, }, // A4: AND A, H
		{ L"AND", Function::AND, Addressing::ByteReg_A, Addressing::ByteReg_L, 4, 0, 8, }, // A5: AND A, L
		{ L"AND", Function::AND, Addressing::ByteReg_A, Addressing::WordReg_HLRef, 7, 0, 19, }, // A6: AND A, (HL)
		{ L"AND", Function::AND, Addressing::ByteReg_A, Addressing::ByteReg_A, 4, 0, 0, }, // A7: AND A, A
		{ L"XOR", Function::XOR, Addressing::ByteReg_A, Addressing::ByteReg_B, 4, 0, 0, }, // A8: XOR A, B
		{ L"XOR", Function::XOR, Addressing::ByteReg_A, Addressing::ByteReg_C, 4, 0, 0, }, // A9: XOR A, C
		{ L"XOR", Function::XOR, Addressing::ByteReg_A, Addressing::ByteReg_D, 4, 0, 0, }, // AA: XOR A, D
		{ L"XOR", Function::XOR, Addressing::ByteReg_A, Addressing::ByteReg_E, 4, 0, 0, }, // AB: XOR A, E
		{ L"XOR", Function::XOR, Addressing::ByteReg_A, Addressing::ByteReg_H, 4, 0, 8, }, // AC: XOR A, H
		{ L"XOR", Function::XOR, Addressing::ByteReg_A, Addressing::ByteReg_L, 4, 0, 8, }, // AD: XOR A, L
		{ L"XOR", Function::XOR, Addressing::ByteReg_A, Addressing::WordReg_HLRef, 7, 0, 19, }, // AE: XOR A, (HL)
		{ L"XOR", Function::XOR, Addressing::ByteReg_A, Addressing::ByteReg_A, 4, 0, 0, }, // AF: XOR A, A
		{ L"OR", Function::OR, Addressing::ByteReg_A, Addressing::ByteReg_B, 4, 0, 0, }, // B0: OR A, B
		{ L"OR", Function::OR, Addressing::ByteReg_A, Addressing::ByteReg_C, 4, 0, 0, }, // B1: OR A, C
		{ L"OR", Function::OR, Addressing::ByteReg_A, Addressing::ByteReg_D, 4, 0, 0, }, // B2: OR A, D
		{ L"OR", Function::OR, Addressing::ByteReg_A, Addressing::ByteReg_E, 4, 0, 0, }, // B3: OR A, E
		{ L"OR", Function::OR, Addressing::ByteReg_A, Addressing::ByteReg_H, 4, 0, 8, }, // B4: OR A, H
		{ L"OR", Function::OR, Addressing::ByteReg_A, Addressing::ByteReg_L, 4, 0, 8, }, // B5: OR A, L
		{ L"OR", Function::OR, Addressing::ByteReg_A, Addressing::WordReg_HLRef, 7, 0, 19, }, // B6: OR A, (HL)
		{ L"OR", Function::OR, Addressing::ByteReg_A, Addressing::ByteReg_A, 4, 0, 0, }, // B7: OR A, A
		{ L"CP", Function::CMP, Addressing::ByteReg_A, Addressing::ByteReg_B, 4, 0, 0, }, // B8: CP A, B
		{ L"CP", Function::CMP, Addressing::ByteReg_A, Addressing::ByteReg_C, 4, 0, 0, }, // B9: CP A, C
		{ L"CP", Function::CMP, Addressing::ByteReg_A, Addressing::ByteReg_D, 4, 0, 0, }, // BA: CP A, D
		{ L"CP", Function::CMP, Addressing::ByteReg_A, Addressing::ByteReg_E, 4, 0, 0, }, // BB: CP A, E
		{ L"CP", Function::CMP, Addressing::ByteReg_A, Addressing::ByteReg_H, 4, 0, 8, }, // BC: CP A, H
		{ L"CP", Function::CMP, Addressing::ByteReg_A, Addressing::ByteReg_L, 4, 0, 8, }, // BD: CP A, L
		{ L"CP", Function::CMP, Addressing::ByteReg_A, Addressing::WordReg_HLRef, 7, 0, 19, }, // BE: CP A, (HL)
		{ L"CP", Function::CMP, Addressing::ByteReg_A, Addressing::ByteReg_A, 4, 0, 0, }, // BF: CP A, A
		{ L"RET", Function::RET, Addressing::Flag_NZ, Addressing::None, 5, 11, 0, }, // C0: RET NZ
		{ L"POP", Function::POP, Addressing::WordReg_BC, Addressing::None, 10, 0, 0, }, // C1: POP BC
		{ L"JP", Function::JMP, Addressing::Flag_NZ, Addressing::Address, 10, 10, 0, }, // C2nnnn: JP NZ, nnnn
		{ L"JP", Function::JMP, Addressing::Address, Addressing::None, 10, 0, 0, }, // C3nnnn: JP nnnn
		{ L"CALL", Function::CALL, Addressing::Flag_NZ, Addressing::Address, 10, 17, 0, }, // C4nnnn: CALL NZ, nnnn
		{ L"PUSH", Function::PUSH, Addressing::WordReg_BC, Addressing::None, 11, 0, 0, }, // C5: PUSH BC
		{ L"ADD", Function::ADD, Addressing::ByteReg_A, Addressing::ImmediateByte, 7, 0, 0, }, // C6nn: ADD A, nn
		{ L"RST", Function::RST, Addressing::Rst00, Addressing::None, 11, 0, 0, }, // C7: RST 00h
		{ L"RET", Function::RET, Addressing::Flag_Z, Addressing::None, 5, 11, 0, }, // C8: RET Z
		{ L"RET", Function::RET, Addressing::None, Addressing::None, 10, 0, 0, }, // C9: RET
		{ L"JP", Function::JMP, Addressing::Flag_Z, Addressing::Address, 10, 10, 0, }, // CAnnnn: JP Z, nnnn
		{ L"", Function::PREFIX, Addressing::None, Addressing::None, 0, 0, 0, }, // CB: 
		{ L"CALL", Function::CALL, Addressing::Flag_Z, Addressing::Address, 10, 17, 0, }, // CCnnnn: CALL Z, nnnn
		{ L"CALL", Function::CALL, Addressing::Address, Addressing::None, 17, 0, 0, }, // CDnnnn: CALL nnnn
		{ L"ADC", Function::ADD_CY, Addressing::ByteReg_A, Addressing::ImmediateByte, 7, 0, 0, }, // CEnn: ADC A, nn
		{ L"RST", Function::RST, Addressing::Rst08, Addressing::None, 11, 0, 0, }, // CF: RST 08h
		{ L"RET", Function::RET, Addressing::Flag_NC, Addressing::None, 5, 11, 0, }, // D0: RET NC
		{ L"POP", Function::POP, Addressing::WordReg_DE, Addressing::None, 10, 0, 0, }, // D1: POP DE
		{ L"JP", Function::JMP, Addressing::Flag_NC, Addressing::Address, 10, 10, 0, }, // D2nnnn: JP NC, nnnn
		{ L"OUT", Function::OUT, Addressing::ImmediateByte, Addressing::ByteReg_A, 11, 0, 0, }, // D3nn: OUT nn, A
		{ L"CALL", Function::CALL, Addressing::Flag_NC, Addressing::Address, 10, 17, 0, }, // D4nnnn: CALL NC, nnnn
		{ L"PUSH", Function::PUSH, Addressing::WordReg_DE, Addressing::None, 11, 0, 0, }, // D5: PUSH DE
		{ L"SUB", Function::SUB, Addressing::ByteReg_A, Addressing::ImmediateByte, 7, 0, 0, }, // D6nn: SUB A, nn
		{ L"RST", Function::RST, Addressing::Rst10, Addressing::None, 11, 0, 0, }, // D7: RST 10h
		{ L"RET", Function::RET, Addressing::Flag_CY, Addressing::None, 5, 11, 0, }, // D8: RET CY
		{ L"EXX", Function::EXX, Addressing::None, Addressing::None, 4, 0, 0, }, // D9: EXX
		{ L"JP", Function::JMP, Addressing::Flag_CY, Addressing::Address, 10, 10, 0, }, // DAnnnn: JP CY, nnnn
		{ L"IN", Function::IN, Addressing::ByteReg_A, Addressing::ImmediateByte, 11, 0, 0, }, // DBnn: IN A, nn
		{ L"CALL", Function::CALL, Addressing::Flag_CY, Addressing::Address, 10, 17, 0, }, // DCnnnn: CALL CY, nnnn
		{ L"", Function::PREFIX, Addressing::None, Addressing::None, 0, 0, 0, }, // DD: 
		{ L"SBC", Function::SUB_CY, Addressing::ByteReg_A, Addressing::ImmediateByte, 7, 0, 0, }, // DEnn: SBC A, nn
		{ L"RST", Function::RST, Addressing::Rst18, Addressing::None, 11, 0, 0, }, // DF: RST 18h
		{ L"RET", Function::RET, Addressing::Flag_PO, Addressing::None, 5, 11, 0, }, // E0: RET PO
		{ L"POP", Function::POP, Addressing::WordReg_HL, Addressing::None, 10, 0, 14, }, // E1: POP HL
		{ L"JP", Function::JMP, Addressing::Flag_PO, Addressing::Address, 10, 10, 0, }, // E2nnnn: JP PO, nnnn
		{ L"EX", Function::EX, Addressing::WordReg_SPRef, Addressing::WordReg_HL, 19, 0, 23, }, // E3: EX (SP), HL
		{ L"CALL", Function::CALL, Addressing::Flag_PO, Addressing::Address, 10, 17, 0, }, // E4nnnn: CALL PO, nnnn
		{ L"PUSH", Function::PUSH, Addressing::WordReg_HL, Addressing::None, 11, 0, 15, }, // E5: PUSH HL
		{ L"AND", Function::AND, Addressing::ByteReg_A, Addressing::ImmediateByte, 7, 0, 0, }, // E6nn: AND A, nn
		{ L"RST", Function::RST, Addressing::Rst20, Addressing::None, 11, 0, 0, }, // E7: RST 20h
		{ L"RET", Function::RET, Addressing::Flag_PE, Addressing::None, 5, 11, 0, }, // E8: RET PE
		{ L"JP", Function::JMP, Addressing::WordReg_HL, Addressing::None, 4, 0, 8, }, // E9: JP HL
		{ L"JP", Function::JMP, Addressing::Flag_PE, Addressing::Address, 10, 10, 0, }, // EAnnnn: JP PE, nnnn
		{ L"EX", Function::EX, Addressing::WordReg_DE, Addressing::WordReg_HL, 4, 0, 0, }, // EB: EX DE, HL
		{ L"CALL", Function::CALL, Addressing::Flag_PE, Addressing::Address, 10, 17, 0, }, // ECnnnn: CALL PE, nnnn
		{ L"", Function::PREFIX, Addressing::None, Addressing::None, 0, 0, 0, }, // ED: 
		{ L"XOR", Function::XOR, Addressing::ByteReg_A, Addressing::ImmediateByte, 7, 0, 0, }, // EEnn: XOR A, nn
		{ L"RST", Function::RST, Addressing::Rst28, Addressing::None, 11, 0, 0, }, // EF: RST 28h
		{ L"RET", Function::RET, Addressing::Flag_P, Addressing::None, 5, 11, 0, }, // F0: RET P
		{ L"POP", Function::POP, Addressing::WordReg_AF, Addressing::None, 10, 0, 0, }, // F1: POP AF
		{ L"JP", Function::JMP, Addressing::Flag_P, Addressing::Address, 10, 10, 0, }, // F2nnnn: JP P, nnnn
		{ L"DI", Function::DI, Addressing::None, Addressing::None, 4, 0, 0, }, // F3: DI
		{ L"CALL", Function::CALL, Addressing::Flag_P, Addressing::Address, 10, 17, 0, }, // F4nnnn: CALL P, nnnn
		{ L"PUSH", Function::PUSH, Addressing::WordReg_AF, Addressing::None, 11, 0, 0, }, // F5: PUSH AF
		{ L"OR", Function::OR, Addressing::ByteReg_A, Addressing::ImmediateByte, 7, 0, 0, }, // F6nn: OR A, nn
		{ L"RST", Function::RST, Addressing::Rst30, Addressing::None, 11, 0, 0, }, // F7: RST 30h
		{ L"RET", Function::RET, Addressing::Flag_M, Addressing::None, 5, 11, 0, }, // F8: RET M
		{ L"LD", Function::LOAD, Addressing::WordReg_SP, Addressing::WordReg_HL, 6, 0, 10, }, // F9: LD SP, HL
		{ L"JP", Function::JMP, Addressing::Flag_M, Addressing::Address, 10, 10, 0, }, // FAnnnn: JP M, nnnn
		{ L"EI", Function::EI, Addressing::None, Addressing::None, 4, 0, 0, }, // FB: EI
		{ L"CALL", Function::CALL, Addressing::Flag_M, Addressing::Address, 10, 17, 0, }, // FCnnnn: CALL M, nnnn
		{ L"", Function::PREFIX, Addressing::None, Addressing::None, 0, 0, 0, }, // FD: 
		{ L"CP", Function::CMP, Addressing::ByteReg_A, Addressing::ImmediateByte, 7, 0, 0, }, // FEnn: CP A, nn
		{ L"RST", Function::RST, Addressing::Rst38, Addressing::None, 11, 0, 0, }, // FF: RST 38h
    };

    OpcodeEntry ExtenededOpcodes[0x100] =
    {
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED00: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED01: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED02: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED03: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED04: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED05: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED06: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED07: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED08: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED09: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED0A: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED0B: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED0C: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED0D: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED0E: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED0F: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED10: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED11: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED12: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED13: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED14: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED15: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED16: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED17: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED18: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED19: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED1A: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED1B: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED1C: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED1D: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED1E: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED1F: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED20: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED21: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED22: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED23: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED24: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED25: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED26: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED27: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED28: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED29: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED2A: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED2B: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED2C: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED2D: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED2E: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED2F: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED30: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED31: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED32: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED33: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED34: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED35: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED36: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED37: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED38: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED39: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED3A: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED3B: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED3C: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED3D: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED3E: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED3F: ???
		{ L"IN", Function::IN, Addressing::ByteReg_B, Addressing::ByteReg_C, 12, 0, 0, }, // ED40: IN B, C
		{ L"OUT", Function::OUT, Addressing::ByteReg_C, Addressing::ByteReg_B, 12, 0, 0, }, // ED41: OUT C, B
		{ L"SBC", Function::SUB_CY, Addressing::WordReg_HL, Addressing::WordReg_BC, 15, 0, 0, }, // ED42: SBC HL, BC
		{ L"LD", Function::LOAD, Addressing::AddressWordRef, Addressing::WordReg_BC, 20, 0, 0, }, // ED43nnnn: LD (nnnn), BC
		{ L"NEG", Function::NEG, Addressing::ByteReg_A, Addressing::None, 8, 0, 0, }, // ED44: NEG A
		{ L"RETN", Function::RETN, Addressing::None, Addressing::None, 14, 0, 0, }, // ED45: RETN
		{ L"IM", Function::IM, Addressing::Value0, Addressing::None, 8, 0, 0, }, // ED46: IM 0
		{ L"LD", Function::LOAD, Addressing::ByteReg_I, Addressing::ByteReg_A, 9, 0, 0, }, // ED47: LD I, A
		{ L"IN", Function::IN, Addressing::ByteReg_C, Addressing::ByteReg_C, 12, 0, 0, }, // ED48: IN C, C
		{ L"OUT", Function::OUT, Addressing::ByteReg_C, Addressing::ByteReg_C, 12, 0, 0, }, // ED49: OUT C, C
		{ L"ADC", Function::ADD_CY, Addressing::WordReg_HL, Addressing::WordReg_BC, 15, 0, 0, }, // ED4A: ADC HL, BC
		{ L"LD", Function::LOAD, Addressing::WordReg_BC, Addressing::AddressWordRef, 20, 0, 0, }, // ED4Bnnnn: LD BC, (nnnn)
		{ L"NEG", Function::NEG, Addressing::ByteReg_A, Addressing::None, 8, 0, 0, }, // ED4C: NEG |A
		{ L"RETI", Function::RETI, Addressing::None, Addressing::None, 14, 0, 0, }, // ED4D: RETI
		{ L"IM", Function::IM, Addressing::Value0, Addressing::None, 8, 0, 0, }, // ED4E: IM 0
		{ L"LD", Function::LOAD, Addressing::ByteReg_R, Addressing::ByteReg_A, 9, 0, 0, }, // ED4F: LD R, A
		{ L"IN", Function::IN, Addressing::ByteReg_D, Addressing::ByteReg_C, 12, 0, 0, }, // ED50: IN D, C
		{ L"OUT", Function::OUT, Addressing::ByteReg_C, Addressing::ByteReg_D, 12, 0, 0, }, // ED51: OUT C, D
		{ L"SBC", Function::SUB_CY, Addressing::WordReg_HL, Addressing::WordReg_DE, 15, 0, 0, }, // ED52: SBC HL, DE
		{ L"LD", Function::LOAD, Addressing::AddressWordRef, Addressing::WordReg_DE, 20, 0, 0, }, // ED53nnnn: LD (nnnn), DE
		{ L"NEG", Function::NEG, Addressing::ByteReg_A, Addressing::None, 8, 0, 0, }, // ED54: NEG |A
		{ L"RETN", Function::RETN, Addressing::None, Addressing::None, 14, 0, 0, }, // ED55: RETN
		{ L"IM", Function::IM, Addressing::Value1, Addressing::None, 8, 0, 0, }, // ED56: IM 1
		{ L"LD", Function::LOAD, Addressing::ByteReg_A, Addressing::ByteReg_I, 9, 0, 0, }, // ED57: LD A, I
		{ L"IN", Function::IN, Addressing::ByteReg_E, Addressing::ByteReg_C, 12, 0, 0, }, // ED58: IN E, C
		{ L"OUT", Function::OUT, Addressing::ByteReg_C, Addressing::ByteReg_E, 12, 0, 0, }, // ED59: OUT C, E
		{ L"ADC", Function::ADD_CY, Addressing::WordReg_HL, Addressing::WordReg_DE, 15, 0, 0, }, // ED5A: ADC HL, DE
		{ L"LD", Function::LOAD, Addressing::WordReg_DE, Addressing::AddressWordRef, 20, 0, 0, }, // ED5Bnnnn: LD DE, (nnnn)
		{ L"NEG", Function::NEG, Addressing::ByteReg_A, Addressing::None, 8, 0, 0, }, // ED5C: NEG |A
		{ L"RETN", Function::RETN, Addressing::None, Addressing::None, 14, 0, 0, }, // ED5D: RETN
		{ L"IM", Function::IM, Addressing::Value2, Addressing::None, 8, 0, 0, }, // ED5E: IM 2
		{ L"LD", Function::LOAD, Addressing::ByteReg_A, Addressing::ByteReg_R, 9, 0, 0, }, // ED5F: LD A, R
		{ L"IN", Function::IN, Addressing::ByteReg_H, Addressing::ByteReg_C, 12, 0, 0, }, // ED60: IN H, C
		{ L"OUT", Function::OUT, Addressing::ByteReg_C, Addressing::ByteReg_H, 12, 0, 0, }, // ED61: OUT C, H
		{ L"SBC", Function::SUB_CY, Addressing::WordReg_HL, Addressing::WordReg_HL, 15, 0, 0, }, // ED62: SBC HL, HL
		{ L"LD", Function::LOAD, Addressing::AddressWordRef, Addressing::WordReg_HL, 20, 0, 0, }, // ED63nnnn: LD (nnnn), HL
		{ L"NEG", Function::NEG, Addressing::ByteReg_A, Addressing::None, 8, 0, 0, }, // ED64: NEG |A
		{ L"RETN", Function::RETN, Addressing::None, Addressing::None, 14, 0, 0, }, // ED65: RETN
		{ L"IM", Function::IM, Addressing::Value0, Addressing::None, 8, 0, 0, }, // ED66: IM 0
		{ L"RRD", Function::ROLL_R, Addressing::ByteReg_A, Addressing::None, 18, 0, 0, }, // ED67: RRD A
		{ L"IN", Function::IN, Addressing::ByteReg_L, Addressing::ByteReg_C, 12, 0, 0, }, // ED68: IN L, C
		{ L"OUT", Function::OUT, Addressing::ByteReg_C, Addressing::ByteReg_L, 12, 0, 0, }, // ED69: OUT C, L
		{ L"ADC", Function::ADD_CY, Addressing::WordReg_HL, Addressing::WordReg_HL, 15, 0, 0, }, // ED6A: ADC HL, HL
		{ L"LD", Function::LOAD, Addressing::WordReg_HL, Addressing::AddressWordRef, 20, 0, 0, }, // ED6Bnnnn: LD HL, (nnnn)
		{ L"NEG", Function::NEG, Addressing::ByteReg_A, Addressing::None, 8, 0, 0, }, // ED6C: NEG |A
		{ L"RETN", Function::RETN, Addressing::None, Addressing::None, 14, 0, 0, }, // ED6D: RETN
		{ L"IM", Function::IM, Addressing::Value0, Addressing::None, 8, 0, 0, }, // ED6E: IM 0
		{ L"RLD", Function::ROLL_L, Addressing::ByteReg_A, Addressing::None, 18, 0, 0, }, // ED6F: RLD A
		{ L"IN", Function::IN, Addressing::ByteReg_C, Addressing::None, 12, 0, 0, }, // ED70: *IN C
		{ L"OUT", Function::OUT, Addressing::ByteReg_C, Addressing::Value0, 12, 0, 0, }, // ED71: *OUT C, 0
		{ L"SBC", Function::SUB_CY, Addressing::WordReg_HL, Addressing::WordReg_SP, 15, 0, 0, }, // ED72: SBC HL, SP
		{ L"LD", Function::LOAD, Addressing::AddressWordRef, Addressing::WordReg_SP, 20, 0, 0, }, // ED73nnnn: LD (nnnn), SP
		{ L"NEG", Function::NEG, Addressing::ByteReg_A, Addressing::None, 8, 0, 0, }, // ED74: NEG |A
		{ L"RETN", Function::RETN, Addressing::None, Addressing::None, 14, 0, 0, }, // ED75: RETN
		{ L"IM", Function::IM, Addressing::Value1, Addressing::None, 8, 0, 0, }, // ED76: IM 1
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED77: ???
		{ L"IN", Function::IN, Addressing::ByteReg_A, Addressing::ByteReg_C, 12, 0, 0, }, // ED78: IN A, C
		{ L"OUT", Function::OUT, Addressing::ByteReg_C, Addressing::ByteReg_A, 12, 0, 0, }, // ED79: OUT C, A
		{ L"ADC", Function::ADD_CY, Addressing::WordReg_HL, Addressing::WordReg_SP, 15, 0, 0, }, // ED7A: ADC HL, SP
		{ L"LD", Function::LOAD, Addressing::WordReg_SP, Addressing::AddressWordRef, 20, 0, 0, }, // ED7Bnnnn: LD SP, (nnnn)
		{ L"NEG", Function::NEG, Addressing::ByteReg_A, Addressing::None, 8, 0, 0, }, // ED7C: NEG |A
		{ L"RETN", Function::RETN, Addressing::None, Addressing::None, 14, 0, 0, }, // ED7D: RETN
		{ L"IM", Function::IM, Addressing::Value2, Addressing::None, 8, 0, 0, }, // ED7E: IM 2
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED7F: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED80: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED81: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED82: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED83: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED84: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED85: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED86: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED87: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED88: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED89: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED8A: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED8B: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED8C: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED8D: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED8E: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED8F: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED90: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED91: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED92: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED93: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED94: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED95: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED96: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED97: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED98: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED99: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED9A: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED9B: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED9C: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED9D: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED9E: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED9F: ???
		{ L"LDI", Function::LOAD_I, Addressing::None, Addressing::None, 16, 0, 0, }, // EDA0: LDI
		{ L"CPI", Function::CMP_I, Addressing::None, Addressing::None, 16, 0, 0, }, // EDA1: CPI
		{ L"INI", Function::IN_I, Addressing::None, Addressing::None, 16, 0, 0, }, // EDA2: INI
		{ L"OUTI", Function::OUT_I, Addressing::None, Addressing::None, 16, 0, 0, }, // EDA3: OUTI
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDA4: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDA5: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDA6: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDA7: ???
		{ L"LDD", Function::LOAD_D, Addressing::None, Addressing::None, 16, 0, 0, }, // EDA8: LDD
		{ L"CPD", Function::CMP_D, Addressing::None, Addressing::None, 16, 0, 0, }, // EDA9: CPD
		{ L"IND", Function::IN_D, Addressing::None, Addressing::None, 16, 0, 0, }, // EDAA: IND
		{ L"OUTD", Function::OUT_D, Addressing::None, Addressing::None, 16, 0, 0, }, // EDAB: OUTD
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDAC: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDAD: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDAE: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDAF: ???
		{ L"LDIR", Function::LOAD_IR, Addressing::None, Addressing::None, 16, 21, 0, }, // EDB0: LDIR
		{ L"CPIR", Function::CMP_IR, Addressing::None, Addressing::None, 16, 21, 0, }, // EDB1: CPIR
		{ L"INIR", Function::IN_IR, Addressing::None, Addressing::None, 16, 21, 0, }, // EDB2: INIR
		{ L"OTIR", Function::OUT_IR, Addressing::None, Addressing::None, 16, 21, 0, }, // EDB3: OTIR
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDB4: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDB5: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDB6: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDB7: ???
		{ L"LDDR", Function::LOAD_DR, Addressing::None, Addressing::None, 16, 21, 0, }, // EDB8: LDDR
		{ L"CPDR", Function::CMP_DR, Addressing::None, Addressing::None, 16, 21, 0, }, // EDB9: CPDR
		{ L"INDR", Function::IN_DR, Addressing::None, Addressing::None, 16, 21, 0, }, // EDBA: INDR
		{ L"OTDR", Function::OUT_DR, Addressing::None, Addressing::None, 16, 21, 0, }, // EDBB: OTDR
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDBC: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDBD: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDBE: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDBF: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDC0: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDC1: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDC2: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDC3: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDC4: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDC5: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDC6: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDC7: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDC8: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDC9: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDCA: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDCB: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDCC: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDCD: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDCE: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDCF: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDD0: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDD1: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDD2: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDD3: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDD4: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDD5: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDD6: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDD7: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDD8: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDD9: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDDA: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDDB: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDDC: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDDD: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDDE: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDDF: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDE0: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDE1: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDE2: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDE3: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDE4: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDE5: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDE6: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDE7: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDE8: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDE9: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDEA: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDEB: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDEC: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDED: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDEE: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDEF: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDF0: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDF1: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDF2: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDF3: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDF4: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDF5: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDF6: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDF7: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDF8: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDF9: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDFA: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDFB: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDFC: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDFD: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDFE: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EDFF: ???
    };

    OpcodeEntry BitOpcodes[0x100] =
    {
		{ L"RLC", Function::RL, Addressing::ByteReg_B, Addressing::None, 8, 0, 23, }, // CB00: RLC B
		{ L"RLC", Function::RL, Addressing::ByteReg_C, Addressing::None, 8, 0, 23, }, // CB01: RLC C
		{ L"RLC", Function::RL, Addressing::ByteReg_D, Addressing::None, 8, 0, 23, }, // CB02: RLC D
		{ L"RLC", Function::RL, Addressing::ByteReg_E, Addressing::None, 8, 0, 23, }, // CB03: RLC E
		{ L"RLC", Function::RL, Addressing::ByteReg_H, Addressing::None, 8, 0, 23, }, // CB04: RLC H
		{ L"RLC", Function::RL, Addressing::ByteReg_L, Addressing::None, 8, 0, 23, }, // CB05: RLC L
		{ L"RLC", Function::RL, Addressing::WordReg_HLRef, Addressing::None, 15, 0, 23, }, // CB06: RLC (HL)
		{ L"RLC", Function::RL, Addressing::ByteReg_A, Addressing::None, 8, 0, 23, }, // CB07: RLC A
		{ L"RRC", Function::RR, Addressing::ByteReg_B, Addressing::None, 8, 0, 23, }, // CB08: RRC B
		{ L"RRC", Function::RR, Addressing::ByteReg_C, Addressing::None, 8, 0, 23, }, // CB09: RRC C
		{ L"RRC", Function::RR, Addressing::ByteReg_D, Addressing::None, 8, 0, 23, }, // CB0A: RRC D
		{ L"RRC", Function::RR, Addressing::ByteReg_E, Addressing::None, 8, 0, 23, }, // CB0B: RRC E
		{ L"RRC", Function::RR, Addressing::ByteReg_H, Addressing::None, 8, 0, 23, }, // CB0C: RRC H
		{ L"RRC", Function::RR, Addressing::ByteReg_L, Addressing::None, 8, 0, 23, }, // CB0D: RRC L
		{ L"RRC", Function::RR, Addressing::WordReg_HLRef, Addressing::None, 15, 0, 23, }, // CB0E: RRC (HL)
		{ L"RRC", Function::RR, Addressing::ByteReg_A, Addressing::None, 8, 0, 23, }, // CB0F: RRC A
		{ L"RL", Function::RL_CY, Addressing::ByteReg_B, Addressing::None, 4, 0, 23, }, // CB10: RL B
		{ L"RL", Function::RL_CY, Addressing::ByteReg_C, Addressing::None, 4, 0, 23, }, // CB11: RL C
		{ L"RL", Function::RL_CY, Addressing::ByteReg_D, Addressing::None, 4, 0, 23, }, // CB12: RL D
		{ L"RL", Function::RL_CY, Addressing::ByteReg_E, Addressing::None, 4, 0, 23, }, // CB13: RL E
		{ L"RL", Function::RL_CY, Addressing::ByteReg_H, Addressing::None, 4, 0, 23, }, // CB14: RL H
		{ L"RL", Function::RL_CY, Addressing::ByteReg_L, Addressing::None, 4, 0, 23, }, // CB15: RL L
		{ L"RL", Function::RL_CY, Addressing::WordReg_HLRef, Addressing::None, 23, 0, 23, }, // CB16: RL (HL)
		{ L"RL", Function::RL_CY, Addressing::ByteReg_A, Addressing::None, 4, 0, 23, }, // CB17: RL A
		{ L"RR", Function::RR_CY, Addressing::ByteReg_B, Addressing::None, 4, 0, 23, }, // CB18: RR B
		{ L"RR", Function::RR_CY, Addressing::ByteReg_C, Addressing::None, 4, 0, 23, }, // CB19: RR C
		{ L"RR", Function::RR_CY, Addressing::ByteReg_D, Addressing::None, 4, 0, 23, }, // CB1A: RR D
		{ L"RR", Function::RR_CY, Addressing::ByteReg_E, Addressing::None, 4, 0, 23, }, // CB1B: RR E
		{ L"RR", Function::RR_CY, Addressing::ByteReg_H, Addressing::None, 4, 0, 23, }, // CB1C: RR H
		{ L"RR", Function::RR_CY, Addressing::ByteReg_L, Addressing::None, 4, 0, 23, }, // CB1D: RR L
		{ L"RR", Function::RR_CY, Addressing::WordReg_HLRef, Addressing::None, 15, 0, 23, }, // CB1E: RR (HL)
		{ L"RR", Function::RR_CY, Addressing::ByteReg_A, Addressing::None, 4, 0, 23, }, // CB1F: RR A
		{ L"SLA", Function::SL_SIGNED, Addressing::ByteReg_B, Addressing::None, 8, 0, 23, }, // CB20: SLA B
		{ L"SLA", Function::SL_SIGNED, Addressing::ByteReg_C, Addressing::None, 8, 0, 23, }, // CB21: SLA C
		{ L"SLA", Function::SL_SIGNED, Addressing::ByteReg_D, Addressing::None, 8, 0, 23, }, // CB22: SLA D
		{ L"SLA", Function::SL_SIGNED, Addressing::ByteReg_E, Addressing::None, 8, 0, 23, }, // CB23: SLA E
		{ L"SLA", Function::SL_SIGNED, Addressing::ByteReg_H, Addressing::None, 8, 0, 23, }, // CB24: SLA H
		{ L"SLA", Function::SL_SIGNED, Addressing::ByteReg_L, Addressing::None, 8, 0, 23, }, // CB25: SLA L
		{ L"SLA", Function::SL_SIGNED, Addressing::WordReg_HLRef, Addressing::None, 15, 0, 23, }, // CB26: SLA (HL)
		{ L"SLA", Function::SL_SIGNED, Addressing::ByteReg_A, Addressing::None, 8, 0, 23, }, // CB27: SLA A
		{ L"SRA", Function::SR_SIGNED, Addressing::ByteReg_B, Addressing::None, 4, 0, 23, }, // CB28: SRA B
		{ L"SRA", Function::SR_SIGNED, Addressing::ByteReg_C, Addressing::None, 4, 0, 23, }, // CB29: SRA C
		{ L"SRA", Function::SR_SIGNED, Addressing::ByteReg_D, Addressing::None, 4, 0, 23, }, // CB2A: SRA D
		{ L"SRA", Function::SR_SIGNED, Addressing::ByteReg_E, Addressing::None, 4, 0, 23, }, // CB2B: SRA E
		{ L"SRA", Function::SR_SIGNED, Addressing::ByteReg_H, Addressing::None, 4, 0, 23, }, // CB2C: SRA H
		{ L"SRA", Function::SR_SIGNED, Addressing::ByteReg_L, Addressing::None, 4, 0, 23, }, // CB2D: SRA L
		{ L"SRA", Function::SR_SIGNED, Addressing::WordReg_HLRef, Addressing::None, 15, 0, 23, }, // CB2E: SRA (HL)
		{ L"SRA", Function::SR_SIGNED, Addressing::ByteReg_A, Addressing::None, 4, 0, 23, }, // CB2F: SRA A
		{ L"SLL", Function::SL_L, Addressing::ByteReg_B, Addressing::None, 8, 0, 23, }, // CB30: *SLL B
		{ L"SLL", Function::SL_L, Addressing::ByteReg_C, Addressing::None, 8, 0, 23, }, // CB31: *SLL C
		{ L"SLL", Function::SL_L, Addressing::ByteReg_D, Addressing::None, 8, 0, 23, }, // CB32: *SLL D
		{ L"SLL", Function::SL_L, Addressing::ByteReg_E, Addressing::None, 8, 0, 23, }, // CB33: *SLL E
		{ L"SLL", Function::SL_L, Addressing::ByteReg_H, Addressing::None, 8, 0, 23, }, // CB34: *SLL H
		{ L"SLL", Function::SL_L, Addressing::ByteReg_L, Addressing::None, 8, 0, 23, }, // CB35: *SLL L
		{ L"SLL", Function::SL_L, Addressing::WordReg_HLRef, Addressing::None, 15, 0, 23, }, // CB36: *SLL (HL)
		{ L"SLL", Function::SL_L, Addressing::ByteReg_A, Addressing::None, 8, 0, 23, }, // CB37: *SLL A
		{ L"SRL", Function::SR_L, Addressing::ByteReg_B, Addressing::None, 8, 0, 23, }, // CB38: SRL B
		{ L"SRL", Function::SR_L, Addressing::ByteReg_C, Addressing::None, 8, 0, 23, }, // CB39: SRL C
		{ L"SRL", Function::SR_L, Addressing::ByteReg_D, Addressing::None, 8, 0, 23, }, // CB3A: SRL D
		{ L"SRL", Function::SR_L, Addressing::ByteReg_E, Addressing::None, 8, 0, 23, }, // CB3B: SRL E
		{ L"SRL", Function::SR_L, Addressing::ByteReg_H, Addressing::None, 8, 0, 23, }, // CB3C: SRL H
		{ L"SRL", Function::SR_L, Addressing::ByteReg_L, Addressing::None, 8, 0, 23, }, // CB3D: SRL L
		{ L"SRL", Function::SR_L, Addressing::WordReg_HLRef, Addressing::None, 15, 0, 23, }, // CB3E: SRL (HL)
		{ L"SRL", Function::SR_L, Addressing::ByteReg_A, Addressing::None, 8, 0, 23, }, // CB3F: SRL A
		{ L"BIT", Function::BIT, Addressing::Value0, Addressing::ByteReg_B, 8, 0, 20, }, // CB40: BIT 0, B
		{ L"BIT", Function::BIT, Addressing::Value0, Addressing::ByteReg_C, 8, 0, 20, }, // CB41: BIT 0, C
		{ L"BIT", Function::BIT, Addressing::Value0, Addressing::ByteReg_D, 8, 0, 20, }, // CB42: BIT 0, D
		{ L"BIT", Function::BIT, Addressing::Value0, Addressing::ByteReg_E, 8, 0, 20, }, // CB43: BIT 0, E
		{ L"BIT", Function::BIT, Addressing::Value0, Addressing::ByteReg_H, 8, 0, 20, }, // CB44: BIT 0, H
		{ L"BIT", Function::BIT, Addressing::Value0, Addressing::ByteReg_L, 8, 0, 20, }, // CB45: BIT 0, L
		{ L"BIT", Function::BIT, Addressing::Value0, Addressing::WordReg_HLRef, 12, 0, 20, }, // CB46: BIT 0, (HL)
		{ L"BIT", Function::BIT, Addressing::Value0, Addressing::ByteReg_A, 8, 0, 20, }, // CB47: BIT 0, A
		{ L"BIT", Function::BIT, Addressing::Value1, Addressing::ByteReg_B, 8, 0, 20, }, // CB48: BIT 1, B
		{ L"BIT", Function::BIT, Addressing::Value1, Addressing::ByteReg_C, 8, 0, 20, }, // CB49: BIT 1, C
		{ L"BIT", Function::BIT, Addressing::Value1, Addressing::ByteReg_D, 8, 0, 20, }, // CB4A: BIT 1, D
		{ L"BIT", Function::BIT, Addressing::Value1, Addressing::ByteReg_E, 8, 0, 20, }, // CB4B: BIT 1, E
		{ L"BIT", Function::BIT, Addressing::Value1, Addressing::ByteReg_H, 8, 0, 20, }, // CB4C: BIT 1, H
		{ L"BIT", Function::BIT, Addressing::Value1, Addressing::ByteReg_L, 8, 0, 20, }, // CB4D: BIT 1, L
		{ L"BIT", Function::BIT, Addressing::Value1, Addressing::WordReg_HLRef, 12, 0, 20, }, // CB4E: BIT 1, (HL)
		{ L"BIT", Function::BIT, Addressing::Value1, Addressing::ByteReg_A, 8, 0, 20, }, // CB4F: BIT 1, A
		{ L"BIT", Function::BIT, Addressing::Value2, Addressing::ByteReg_B, 8, 0, 20, }, // CB50: BIT 2, B
		{ L"BIT", Function::BIT, Addressing::Value2, Addressing::ByteReg_C, 8, 0, 20, }, // CB51: BIT 2, C
		{ L"BIT", Function::BIT, Addressing::Value2, Addressing::ByteReg_D, 8, 0, 20, }, // CB52: BIT 2, D
		{ L"BIT", Function::BIT, Addressing::Value2, Addressing::ByteReg_E, 8, 0, 20, }, // CB53: BIT 2, E
		{ L"BIT", Function::BIT, Addressing::Value2, Addressing::ByteReg_H, 8, 0, 20, }, // CB54: BIT 2, H
		{ L"BIT", Function::BIT, Addressing::Value2, Addressing::ByteReg_L, 8, 0, 20, }, // CB55: BIT 2, L
		{ L"BIT", Function::BIT, Addressing::Value2, Addressing::WordReg_HLRef, 12, 0, 20, }, // CB56: BIT 2, (HL)
		{ L"BIT", Function::BIT, Addressing::Value2, Addressing::ByteReg_A, 8, 0, 20, }, // CB57: BIT 2, A
		{ L"BIT", Function::BIT, Addressing::Value3, Addressing::ByteReg_B, 8, 0, 20, }, // CB58: BIT 3, B
		{ L"BIT", Function::BIT, Addressing::Value3, Addressing::ByteReg_C, 8, 0, 20, }, // CB59: BIT 3, C
		{ L"BIT", Function::BIT, Addressing::Value3, Addressing::ByteReg_D, 8, 0, 20, }, // CB5A: BIT 3, D
		{ L"BIT", Function::BIT, Addressing::Value3, Addressing::ByteReg_E, 8, 0, 20, }, // CB5B: BIT 3, E
		{ L"BIT", Function::BIT, Addressing::Value3, Addressing::ByteReg_H, 8, 0, 20, }, // CB5C: BIT 3, H
		{ L"BIT", Function::BIT, Addressing::Value3, Addressing::ByteReg_L, 8, 0, 20, }, // CB5D: BIT 3, L
		{ L"BIT", Function::BIT, Addressing::Value3, Addressing::WordReg_HLRef, 12, 0, 20, }, // CB5E: BIT 3, (HL)
		{ L"BIT", Function::BIT, Addressing::Value3, Addressing::ByteReg_A, 8, 0, 20, }, // CB5F: BIT 3, A
		{ L"BIT", Function::BIT, Addressing::Value4, Addressing::ByteReg_B, 8, 0, 20, }, // CB60: BIT 4, B
		{ L"BIT", Function::BIT, Addressing::Value4, Addressing::ByteReg_C, 8, 0, 20, }, // CB61: BIT 4, C
		{ L"BIT", Function::BIT, Addressing::Value4, Addressing::ByteReg_D, 8, 0, 20, }, // CB62: BIT 4, D
		{ L"BIT", Function::BIT, Addressing::Value4, Addressing::ByteReg_E, 8, 0, 20, }, // CB63: BIT 4, E
		{ L"BIT", Function::BIT, Addressing::Value4, Addressing::ByteReg_H, 8, 0, 20, }, // CB64: BIT 4, H
		{ L"BIT", Function::BIT, Addressing::Value4, Addressing::ByteReg_L, 8, 0, 20, }, // CB65: BIT 4, L
		{ L"BIT", Function::BIT, Addressing::Value4, Addressing::WordReg_HLRef, 12, 0, 20, }, // CB66: BIT 4, (HL)
		{ L"BIT", Function::BIT, Addressing::Value4, Addressing::ByteReg_A, 8, 0, 20, }, // CB67: BIT 4, A
		{ L"BIT", Function::BIT, Addressing::Value5, Addressing::ByteReg_B, 8, 0, 20, }, // CB68: BIT 5, B
		{ L"BIT", Function::BIT, Addressing::Value5, Addressing::ByteReg_C, 8, 0, 20, }, // CB69: BIT 5, C
		{ L"BIT", Function::BIT, Addressing::Value5, Addressing::ByteReg_D, 8, 0, 20, }, // CB6A: BIT 5, D
		{ L"BIT", Function::BIT, Addressing::Value5, Addressing::ByteReg_E, 8, 0, 20, }, // CB6B: BIT 5, E
		{ L"BIT", Function::BIT, Addressing::Value5, Addressing::ByteReg_H, 8, 0, 20, }, // CB6C: BIT 5, H
		{ L"BIT", Function::BIT, Addressing::Value5, Addressing::ByteReg_L, 8, 0, 20, }, // CB6D: BIT 5, L
		{ L"BIT", Function::BIT, Addressing::Value5, Addressing::WordReg_HLRef, 12, 0, 20, }, // CB6E: BIT 5, (HL)
		{ L"BIT", Function::BIT, Addressing::Value5, Addressing::ByteReg_A, 8, 0, 20, }, // CB6F: BIT 5, A
		{ L"BIT", Function::BIT, Addressing::Value6, Addressing::ByteReg_B, 8, 0, 20, }, // CB70: BIT 6, B
		{ L"BIT", Function::BIT, Addressing::Value6, Addressing::ByteReg_C, 8, 0, 20, }, // CB71: BIT 6, C
		{ L"BIT", Function::BIT, Addressing::Value6, Addressing::ByteReg_D, 8, 0, 20, }, // CB72: BIT 6, D
		{ L"BIT", Function::BIT, Addressing::Value6, Addressing::ByteReg_E, 8, 0, 20, }, // CB73: BIT 6, E
		{ L"BIT", Function::BIT, Addressing::Value6, Addressing::ByteReg_H, 8, 0, 20, }, // CB74: BIT 6, H
		{ L"BIT", Function::BIT, Addressing::Value6, Addressing::ByteReg_L, 8, 0, 20, }, // CB75: BIT 6, L
		{ L"BIT", Function::BIT, Addressing::Value6, Addressing::WordReg_HLRef, 12, 0, 20, }, // CB76: BIT 6, (HL)
		{ L"BIT", Function::BIT, Addressing::Value6, Addressing::ByteReg_A, 8, 0, 20, }, // CB77: BIT 6, A
		{ L"BIT", Function::BIT, Addressing::Value7, Addressing::ByteReg_B, 8, 0, 20, }, // CB78: BIT 7, B
		{ L"BIT", Function::BIT, Addressing::Value7, Addressing::ByteReg_C, 8, 0, 20, }, // CB79: BIT 7, C
		{ L"BIT", Function::BIT, Addressing::Value7, Addressing::ByteReg_D, 8, 0, 20, }, // CB7A: BIT 7, D
		{ L"BIT", Function::BIT, Addressing::Value7, Addressing::ByteReg_E, 8, 0, 20, }, // CB7B: BIT 7, E
		{ L"BIT", Function::BIT, Addressing::Value7, Addressing::ByteReg_H, 8, 0, 20, }, // CB7C: BIT 7, H
		{ L"BIT", Function::BIT, Addressing::Value7, Addressing::ByteReg_L, 8, 0, 20, }, // CB7D: BIT 7, L
		{ L"BIT", Function::BIT, Addressing::Value7, Addressing::WordReg_HLRef, 12, 0, 20, }, // CB7E: BIT 7, (HL)
		{ L"BIT", Function::BIT, Addressing::Value7, Addressing::ByteReg_A, 8, 0, 20, }, // CB7F: BIT 7, A
		{ L"RES", Function::RES, Addressing::Value0, Addressing::ByteReg_B, 8, 0, 23, }, // CB80: RES 0, B
		{ L"RES", Function::RES, Addressing::Value0, Addressing::ByteReg_C, 8, 0, 23, }, // CB81: RES 0, C
		{ L"RES", Function::RES, Addressing::Value0, Addressing::ByteReg_D, 8, 0, 23, }, // CB82: RES 0, D
		{ L"RES", Function::RES, Addressing::Value0, Addressing::ByteReg_E, 8, 0, 23, }, // CB83: RES 0, E
		{ L"RES", Function::RES, Addressing::Value0, Addressing::ByteReg_H, 8, 0, 23, }, // CB84: RES 0, H
		{ L"RES", Function::RES, Addressing::Value0, Addressing::ByteReg_L, 8, 0, 23, }, // CB85: RES 0, L
		{ L"RES", Function::RES, Addressing::Value0, Addressing::WordReg_HLRef, 15, 0, 23, }, // CB86: RES 0, (HL)
		{ L"RES", Function::RES, Addressing::Value0, Addressing::ByteReg_A, 8, 0, 23, }, // CB87: RES 0, A
		{ L"RES", Function::RES, Addressing::Value1, Addressing::ByteReg_B, 8, 0, 23, }, // CB88: RES 1, B
		{ L"RES", Function::RES, Addressing::Value1, Addressing::ByteReg_C, 8, 0, 23, }, // CB89: RES 1, C
		{ L"RES", Function::RES, Addressing::Value1, Addressing::ByteReg_D, 8, 0, 23, }, // CB8A: RES 1, D
		{ L"RES", Function::RES, Addressing::Value1, Addressing::ByteReg_E, 8, 0, 23, }, // CB8B: RES 1, E
		{ L"RES", Function::RES, Addressing::Value1, Addressing::ByteReg_H, 8, 0, 23, }, // CB8C: RES 1, H
		{ L"RES", Function::RES, Addressing::Value1, Addressing::ByteReg_L, 8, 0, 23, }, // CB8D: RES 1, L
		{ L"RES", Function::RES, Addressing::Value1, Addressing::WordReg_HLRef, 15, 0, 23, }, // CB8E: RES 1, (HL)
		{ L"RES", Function::RES, Addressing::Value1, Addressing::ByteReg_A, 8, 0, 23, }, // CB8F: RES 1, A
		{ L"RES", Function::RES, Addressing::Value2, Addressing::ByteReg_B, 8, 0, 23, }, // CB90: RES 2, B
		{ L"RES", Function::RES, Addressing::Value2, Addressing::ByteReg_C, 8, 0, 23, }, // CB91: RES 2, C
		{ L"RES", Function::RES, Addressing::Value2, Addressing::ByteReg_D, 8, 0, 23, }, // CB92: RES 2, D
		{ L"RES", Function::RES, Addressing::Value2, Addressing::ByteReg_E, 8, 0, 23, }, // CB93: RES 2, E
		{ L"RES", Function::RES, Addressing::Value2, Addressing::ByteReg_H, 8, 0, 23, }, // CB94: RES 2, H
		{ L"RES", Function::RES, Addressing::Value2, Addressing::ByteReg_L, 8, 0, 23, }, // CB95: RES 2, L
		{ L"RES", Function::RES, Addressing::Value2, Addressing::WordReg_HLRef, 15, 0, 23, }, // CB96: RES 2, (HL)
		{ L"RES", Function::RES, Addressing::Value2, Addressing::ByteReg_A, 8, 0, 23, }, // CB97: RES 2, A
		{ L"RES", Function::RES, Addressing::Value3, Addressing::ByteReg_B, 8, 0, 23, }, // CB98: RES 3, B
		{ L"RES", Function::RES, Addressing::Value3, Addressing::ByteReg_C, 8, 0, 23, }, // CB99: RES 3, C
		{ L"RES", Function::RES, Addressing::Value3, Addressing::ByteReg_D, 8, 0, 23, }, // CB9A: RES 3, D
		{ L"RES", Function::RES, Addressing::Value3, Addressing::ByteReg_E, 8, 0, 23, }, // CB9B: RES 3, E
		{ L"RES", Function::RES, Addressing::Value3, Addressing::ByteReg_H, 8, 0, 23, }, // CB9C: RES 3, H
		{ L"RES", Function::RES, Addressing::Value3, Addressing::ByteReg_L, 8, 0, 23, }, // CB9D: RES 3, L
		{ L"RES", Function::RES, Addressing::Value3, Addressing::WordReg_HLRef, 15, 0, 23, }, // CB9E: RES 3, (HL)
		{ L"RES", Function::RES, Addressing::Value3, Addressing::ByteReg_A, 8, 0, 23, }, // CB9F: RES 3, A
		{ L"RES", Function::RES, Addressing::Value4, Addressing::ByteReg_B, 8, 0, 23, }, // CBA0: RES 4, B
		{ L"RES", Function::RES, Addressing::Value4, Addressing::ByteReg_C, 8, 0, 23, }, // CBA1: RES 4, C
		{ L"RES", Function::RES, Addressing::Value4, Addressing::ByteReg_D, 8, 0, 23, }, // CBA2: RES 4, D
		{ L"RES", Function::RES, Addressing::Value4, Addressing::ByteReg_E, 8, 0, 23, }, // CBA3: RES 4, E
		{ L"RES", Function::RES, Addressing::Value4, Addressing::ByteReg_H, 8, 0, 23, }, // CBA4: RES 4, H
		{ L"RES", Function::RES, Addressing::Value4, Addressing::ByteReg_L, 8, 0, 23, }, // CBA5: RES 4, L
		{ L"RES", Function::RES, Addressing::Value4, Addressing::WordReg_HLRef, 15, 0, 23, }, // CBA6: RES 4, (HL)
		{ L"RES", Function::RES, Addressing::Value4, Addressing::ByteReg_A, 8, 0, 23, }, // CBA7: RES 4, A
		{ L"RES", Function::RES, Addressing::Value5, Addressing::ByteReg_B, 8, 0, 23, }, // CBA8: RES 5, B
		{ L"RES", Function::RES, Addressing::Value5, Addressing::ByteReg_C, 8, 0, 23, }, // CBA9: RES 5, C
		{ L"RES", Function::RES, Addressing::Value5, Addressing::ByteReg_D, 8, 0, 23, }, // CBAA: RES 5, D
		{ L"RES", Function::RES, Addressing::Value5, Addressing::ByteReg_E, 8, 0, 23, }, // CBAB: RES 5, E
		{ L"RES", Function::RES, Addressing::Value5, Addressing::ByteReg_H, 8, 0, 23, }, // CBAC: RES 5, H
		{ L"RES", Function::RES, Addressing::Value5, Addressing::ByteReg_L, 8, 0, 23, }, // CBAD: RES 5, L
		{ L"RES", Function::RES, Addressing::Value5, Addressing::WordReg_HLRef, 15, 0, 23, }, // CBAE: RES 5, (HL)
		{ L"RES", Function::RES, Addressing::Value5, Addressing::ByteReg_A, 8, 0, 23, }, // CBAF: RES 5, A
		{ L"RES", Function::RES, Addressing::Value6, Addressing::ByteReg_B, 8, 0, 23, }, // CBB0: RES 6, B
		{ L"RES", Function::RES, Addressing::Value6, Addressing::ByteReg_C, 8, 0, 23, }, // CBB1: RES 6, C
		{ L"RES", Function::RES, Addressing::Value6, Addressing::ByteReg_D, 8, 0, 23, }, // CBB2: RES 6, D
		{ L"RES", Function::RES, Addressing::Value6, Addressing::ByteReg_E, 8, 0, 23, }, // CBB3: RES 6, E
		{ L"RES", Function::RES, Addressing::Value6, Addressing::ByteReg_H, 8, 0, 23, }, // CBB4: RES 6, H
		{ L"RES", Function::RES, Addressing::Value6, Addressing::ByteReg_L, 8, 0, 23, }, // CBB5: RES 6, L
		{ L"RES", Function::RES, Addressing::Value6, Addressing::WordReg_HLRef, 15, 0, 23, }, // CBB6: RES 6, (HL)
		{ L"RES", Function::RES, Addressing::Value6, Addressing::ByteReg_A, 8, 0, 23, }, // CBB7: RES 6, A
		{ L"RES", Function::RES, Addressing::Value7, Addressing::ByteReg_B, 8, 0, 23, }, // CBB8: RES 7, B
		{ L"RES", Function::RES, Addressing::Value7, Addressing::ByteReg_C, 8, 0, 23, }, // CBB9: RES 7, C
		{ L"RES", Function::RES, Addressing::Value7, Addressing::ByteReg_D, 8, 0, 23, }, // CBBA: RES 7, D
		{ L"RES", Function::RES, Addressing::Value7, Addressing::ByteReg_E, 8, 0, 23, }, // CBBB: RES 7, E
		{ L"RES", Function::RES, Addressing::Value7, Addressing::ByteReg_H, 8, 0, 23, }, // CBBC: RES 7, H
		{ L"RES", Function::RES, Addressing::Value7, Addressing::ByteReg_L, 8, 0, 23, }, // CBBD: RES 7, L
		{ L"RES", Function::RES, Addressing::Value7, Addressing::WordReg_HLRef, 15, 0, 23, }, // CBBE: RES 7, (HL)
		{ L"RES", Function::RES, Addressing::Value7, Addressing::ByteReg_A, 8, 0, 23, }, // CBBF: RES 7, A
		{ L"SET", Function::SET, Addressing::Value0, Addressing::ByteReg_B, 8, 0, 23, }, // CBC0: SET 0, B
		{ L"SET", Function::SET, Addressing::Value0, Addressing::ByteReg_C, 8, 0, 23, }, // CBC1: SET 0, C
		{ L"SET", Function::SET, Addressing::Value0, Addressing::ByteReg_D, 8, 0, 23, }, // CBC2: SET 0, D
		{ L"SET", Function::SET, Addressing::Value0, Addressing::ByteReg_E, 8, 0, 23, }, // CBC3: SET 0, E
		{ L"SET", Function::SET, Addressing::Value0, Addressing::ByteReg_H, 8, 0, 23, }, // CBC4: SET 0, H
		{ L"SET", Function::SET, Addressing::Value0, Addressing::ByteReg_L, 8, 0, 23, }, // CBC5: SET 0, L
		{ L"SET", Function::SET, Addressing::Value0, Addressing::WordReg_HLRef, 15, 0, 23, }, // CBC6: SET 0, (HL)
		{ L"SET", Function::SET, Addressing::Value0, Addressing::ByteReg_A, 8, 0, 23, }, // CBC7: SET 0, A
		{ L"SET", Function::SET, Addressing::Value1, Addressing::ByteReg_B, 8, 0, 23, }, // CBC8: SET 1, B
		{ L"SET", Function::SET, Addressing::Value1, Addressing::ByteReg_C, 8, 0, 23, }, // CBC9: SET 1, C
		{ L"SET", Function::SET, Addressing::Value1, Addressing::ByteReg_D, 8, 0, 23, }, // CBCA: SET 1, D
		{ L"SET", Function::SET, Addressing::Value1, Addressing::ByteReg_E, 8, 0, 23, }, // CBCB: SET 1, E
		{ L"SET", Function::SET, Addressing::Value1, Addressing::ByteReg_H, 8, 0, 23, }, // CBCC: SET 1, H
		{ L"SET", Function::SET, Addressing::Value1, Addressing::ByteReg_L, 8, 0, 23, }, // CBCD: SET 1, L
		{ L"SET", Function::SET, Addressing::Value1, Addressing::WordReg_HLRef, 15, 0, 23, }, // CBCE: SET 1, (HL)
		{ L"SET", Function::SET, Addressing::Value1, Addressing::ByteReg_A, 8, 0, 23, }, // CBCF: SET 1, A
		{ L"SET", Function::SET, Addressing::Value2, Addressing::ByteReg_B, 8, 0, 23, }, // CBD0: SET 2, B
		{ L"SET", Function::SET, Addressing::Value2, Addressing::ByteReg_C, 8, 0, 23, }, // CBD1: SET 2, C
		{ L"SET", Function::SET, Addressing::Value2, Addressing::ByteReg_D, 8, 0, 23, }, // CBD2: SET 2, D
		{ L"SET", Function::SET, Addressing::Value2, Addressing::ByteReg_E, 8, 0, 23, }, // CBD3: SET 2, E
		{ L"SET", Function::SET, Addressing::Value2, Addressing::ByteReg_H, 8, 0, 23, }, // CBD4: SET 2, H
		{ L"SET", Function::SET, Addressing::Value2, Addressing::ByteReg_L, 8, 0, 23, }, // CBD5: SET 2, L
		{ L"SET", Function::SET, Addressing::Value2, Addressing::WordReg_HLRef, 15, 0, 23, }, // CBD6: SET 2, (HL)
		{ L"SET", Function::SET, Addressing::Value2, Addressing::ByteReg_A, 8, 0, 23, }, // CBD7: SET 2, A
		{ L"SET", Function::SET, Addressing::Value3, Addressing::ByteReg_B, 8, 0, 23, }, // CBD8: SET 3, B
		{ L"SET", Function::SET, Addressing::Value3, Addressing::ByteReg_C, 8, 0, 23, }, // CBD9: SET 3, C
		{ L"SET", Function::SET, Addressing::Value3, Addressing::ByteReg_D, 8, 0, 23, }, // CBDA: SET 3, D
		{ L"SET", Function::SET, Addressing::Value3, Addressing::ByteReg_E, 8, 0, 23, }, // CBDB: SET 3, E
		{ L"SET", Function::SET, Addressing::Value3, Addressing::ByteReg_H, 8, 0, 23, }, // CBDC: SET 3, H
		{ L"SET", Function::SET, Addressing::Value3, Addressing::ByteReg_L, 8, 0, 23, }, // CBDD: SET 3, L
		{ L"SET", Function::SET, Addressing::Value3, Addressing::WordReg_HLRef, 15, 0, 23, }, // CBDE: SET 3, (HL)
		{ L"SET", Function::SET, Addressing::Value3, Addressing::ByteReg_A, 8, 0, 23, }, // CBDF: SET 3, A
		{ L"SET", Function::SET, Addressing::Value4, Addressing::ByteReg_B, 8, 0, 23, }, // CBE0: SET 4, B
		{ L"SET", Function::SET, Addressing::Value4, Addressing::ByteReg_C, 8, 0, 23, }, // CBE1: SET 4, C
		{ L"SET", Function::SET, Addressing::Value4, Addressing::ByteReg_D, 8, 0, 23, }, // CBE2: SET 4, D
		{ L"SET", Function::SET, Addressing::Value4, Addressing::ByteReg_E, 8, 0, 23, }, // CBE3: SET 4, E
		{ L"SET", Function::SET, Addressing::Value4, Addressing::ByteReg_H, 8, 0, 23, }, // CBE4: SET 4, H
		{ L"SET", Function::SET, Addressing::Value4, Addressing::ByteReg_L, 8, 0, 23, }, // CBE5: SET 4, L
		{ L"SET", Function::SET, Addressing::Value4, Addressing::WordReg_HLRef, 15, 0, 23, }, // CBE6: SET 4, (HL)
		{ L"SET", Function::SET, Addressing::Value4, Addressing::ByteReg_A, 8, 0, 23, }, // CBE7: SET 4, A
		{ L"SET", Function::SET, Addressing::Value5, Addressing::ByteReg_B, 8, 0, 23, }, // CBE8: SET 5, B
		{ L"SET", Function::SET, Addressing::Value5, Addressing::ByteReg_C, 8, 0, 23, }, // CBE9: SET 5, C
		{ L"SET", Function::SET, Addressing::Value5, Addressing::ByteReg_D, 8, 0, 23, }, // CBEA: SET 5, D
		{ L"SET", Function::SET, Addressing::Value5, Addressing::ByteReg_E, 8, 0, 23, }, // CBEB: SET 5, E
		{ L"SET", Function::SET, Addressing::Value5, Addressing::ByteReg_H, 8, 0, 23, }, // CBEC: SET 5, H
		{ L"SET", Function::SET, Addressing::Value5, Addressing::ByteReg_L, 8, 0, 23, }, // CBED: SET 5, L
		{ L"SET", Function::SET, Addressing::Value5, Addressing::WordReg_HLRef, 15, 0, 23, }, // CBEE: SET 5, (HL)
		{ L"SET", Function::SET, Addressing::Value5, Addressing::ByteReg_A, 8, 0, 23, }, // CBEF: SET 5, A
		{ L"SET", Function::SET, Addressing::Value6, Addressing::ByteReg_B, 8, 0, 23, }, // CBF0: SET 6, B
		{ L"SET", Function::SET, Addressing::Value6, Addressing::ByteReg_C, 8, 0, 23, }, // CBF1: SET 6, C
		{ L"SET", Function::SET, Addressing::Value6, Addressing::ByteReg_D, 8, 0, 23, }, // CBF2: SET 6, D
		{ L"SET", Function::SET, Addressing::Value6, Addressing::ByteReg_E, 8, 0, 23, }, // CBF3: SET 6, E
		{ L"SET", Function::SET, Addressing::Value6, Addressing::ByteReg_H, 8, 0, 23, }, // CBF4: SET 6, H
		{ L"SET", Function::SET, Addressing::Value6, Addressing::ByteReg_L, 8, 0, 23, }, // CBF5: SET 6, L
		{ L"SET", Function::SET, Addressing::Value6, Addressing::WordReg_HLRef, 15, 0, 23, }, // CBF6: SET 6, (HL)
		{ L"SET", Function::SET, Addressing::Value6, Addressing::ByteReg_A, 8, 0, 23, }, // CBF7: SET 6, A
		{ L"SET", Function::SET, Addressing::Value7, Addressing::ByteReg_B, 8, 0, 23, }, // CBF8: SET 7, B
		{ L"SET", Function::SET, Addressing::Value7, Addressing::ByteReg_C, 8, 0, 23, }, // CBF9: SET 7, C
		{ L"SET", Function::SET, Addressing::Value7, Addressing::ByteReg_D, 8, 0, 23, }, // CBFA: SET 7, D
		{ L"SET", Function::SET, Addressing::Value7, Addressing::ByteReg_E, 8, 0, 23, }, // CBFB: SET 7, E
		{ L"SET", Function::SET, Addressing::Value7, Addressing::ByteReg_H, 8, 0, 23, }, // CBFC: SET 7, H
		{ L"SET", Function::SET, Addressing::Value7, Addressing::ByteReg_L, 8, 0, 23, }, // CBFD: SET 7, L
		{ L"SET", Function::SET, Addressing::Value7, Addressing::WordReg_HLRef, 15, 0, 23, }, // CBFE: SET 7, (HL)
		{ L"SET", Function::SET, Addressing::Value7, Addressing::ByteReg_A, 8, 0, 23, }, // CBFF: SET 7, A
    };
}

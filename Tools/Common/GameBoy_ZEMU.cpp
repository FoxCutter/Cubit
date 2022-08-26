namespace z80
{
    OpcodeEntry MainOpcodes[0x100] =
    {
		{ L"NOP", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0, }, // 00: NOP
		{ L"LD", Function::LOAD, Addressing::WordReg_BC, Addressing::ImmediateWord, 12, 0, 0, }, // 01nnnn: LD BC, nnnn
		{ L"LD", Function::LOAD, Addressing::WordReg_BCRef, Addressing::ByteReg_A, 8, 0, 0, }, // 02: LD (BC), A
		{ L"INC", Function::INC, Addressing::WordReg_BC, Addressing::None, 8, 0, 0, }, // 03: INC BC
		{ L"INC", Function::INC, Addressing::ByteReg_B, Addressing::None, 4, 0, 0, }, // 04: INC B
		{ L"DEC", Function::DEC, Addressing::ByteReg_B, Addressing::None, 4, 0, 0, }, // 05: DEC B
		{ L"LD", Function::LOAD, Addressing::ByteReg_B, Addressing::ImmediateByte, 8, 0, 0, }, // 06nn: LD B, nn
		{ L"RLCA", Function::RL, Addressing::ByteReg_A, Addressing::None, 4, 0, 0, }, // 07: RLCA |A
		{ L"LD", Function::LOAD, Addressing::AddressWordRef, Addressing::WordReg_SP, 20, 0, 0, }, // 08nnnn: LD (nnnn), SP
		{ L"ADD", Function::ADD, Addressing::WordReg_HL, Addressing::WordReg_BC, 8, 0, 0, }, // 09: ADD HL, BC
		{ L"LD", Function::LOAD, Addressing::ByteReg_A, Addressing::WordReg_BCRef, 8, 0, 0, }, // 0A: LD A, (BC)
		{ L"DEC", Function::DEC, Addressing::WordReg_BC, Addressing::None, 8, 0, 0, }, // 0B: DEC BC
		{ L"INC", Function::INC, Addressing::ByteReg_C, Addressing::None, 4, 0, 0, }, // 0C: INC C
		{ L"DEC", Function::DEC, Addressing::ByteReg_C, Addressing::None, 4, 0, 0, }, // 0D: DEC C
		{ L"LD", Function::LOAD, Addressing::ByteReg_C, Addressing::ImmediateByte, 8, 0, 0, }, // 0Enn: LD C, nn
		{ L"RRCA", Function::RR, Addressing::ByteReg_A, Addressing::None, 4, 0, 0, }, // 0F: RRCA |A
		{ L"STOP", Function::STOP, Addressing::None, Addressing::None, 4, 0, 0, }, // 10: STOP
		{ L"LD", Function::LOAD, Addressing::WordReg_DE, Addressing::ImmediateWord, 12, 0, 0, }, // 11nnnn: LD DE, nnnn
		{ L"LD", Function::LOAD, Addressing::WordReg_DERef, Addressing::ByteReg_A, 8, 0, 0, }, // 12: LD (DE), A
		{ L"INC", Function::INC, Addressing::WordReg_DE, Addressing::None, 8, 0, 0, }, // 13: INC DE
		{ L"INC", Function::INC, Addressing::ByteReg_D, Addressing::None, 4, 0, 0, }, // 14: INC D
		{ L"DEC", Function::DEC, Addressing::ByteReg_D, Addressing::None, 4, 0, 0, }, // 15: DEC D
		{ L"LD", Function::LOAD, Addressing::ByteReg_D, Addressing::ImmediateByte, 8, 0, 0, }, // 16nn: LD D, nn
		{ L"RLA", Function::RL_CY, Addressing::ByteReg_A, Addressing::None, 4, 0, 0, }, // 17: RLA |A
		{ L"JR", Function::JMPR, Addressing::Displacement, Addressing::None, 12, 0, 0, }, // 18nn: JR e-2
		{ L"ADD", Function::ADD, Addressing::WordReg_HL, Addressing::WordReg_DE, 8, 0, 0, }, // 19: ADD HL, DE
		{ L"LD", Function::LOAD, Addressing::ByteReg_A, Addressing::WordReg_DERef, 8, 0, 0, }, // 1A: LD A, (DE)
		{ L"DEC", Function::DEC, Addressing::WordReg_DE, Addressing::None, 8, 0, 0, }, // 1B: DEC DE
		{ L"INC", Function::INC, Addressing::ByteReg_E, Addressing::None, 4, 0, 0, }, // 1C: INC E
		{ L"DEC", Function::DEC, Addressing::ByteReg_E, Addressing::None, 4, 0, 0, }, // 1D: DEC E
		{ L"LD", Function::LOAD, Addressing::ByteReg_E, Addressing::ImmediateByte, 8, 0, 0, }, // 1Enn: LD E, nn
		{ L"RRA", Function::RR_CY, Addressing::ByteReg_A, Addressing::None, 4, 0, 0, }, // 1F: RRA |A
		{ L"JR", Function::JMPR, Addressing::Flag_NZ, Addressing::Displacement, 8, 12, 0, }, // 20nn: JR NZ, e-2
		{ L"LD", Function::LOAD, Addressing::WordReg_HL, Addressing::ImmediateWord, 12, 0, 0, }, // 21nnnn: LD HL, nnnn
		{ L"LD", Function::LOAD_INC, Addressing::WordReg_HLIRef, Addressing::ByteReg_A, 8, 0, 0, }, // 22: LD (HLI), A
		{ L"INC", Function::INC, Addressing::WordReg_HL, Addressing::None, 8, 0, 0, }, // 23: INC HL
		{ L"INC", Function::INC, Addressing::ByteReg_H, Addressing::None, 4, 0, 0, }, // 24: INC H
		{ L"DEC", Function::DEC, Addressing::ByteReg_H, Addressing::None, 4, 0, 0, }, // 25: DEC H
		{ L"LD", Function::LOAD, Addressing::ByteReg_H, Addressing::ImmediateByte, 8, 0, 0, }, // 26nn: LD H, nn
		{ L"DAA", Function::BCD_ADJUST, Addressing::ByteReg_A, Addressing::None, 4, 0, 0, }, // 27: DAA |A
		{ L"JR", Function::JMPR, Addressing::Flag_Z, Addressing::Displacement, 8, 12, 0, }, // 28nn: JR Z, e-2
		{ L"ADD", Function::ADD, Addressing::WordReg_HL, Addressing::WordReg_HL, 8, 0, 0, }, // 29: ADD HL, HL
		{ L"LD", Function::LOAD_INC, Addressing::ByteReg_A, Addressing::WordReg_HLIRef, 8, 0, 0, }, // 2A: LD A, (HLI)
		{ L"DEC", Function::DEC, Addressing::WordReg_HL, Addressing::None, 8, 0, 0, }, // 2B: DEC HL
		{ L"INC", Function::INC, Addressing::ByteReg_L, Addressing::None, 4, 0, 0, }, // 2C: INC L
		{ L"DEC", Function::DEC, Addressing::ByteReg_L, Addressing::None, 4, 0, 0, }, // 2D: DEC L
		{ L"LD", Function::LOAD, Addressing::ByteReg_L, Addressing::ImmediateByte, 8, 0, 0, }, // 2Enn: LD L, nn
		{ L"CPL", Function::NOT, Addressing::ByteReg_A, Addressing::None, 4, 0, 0, }, // 2F: CPL |A
		{ L"JR", Function::JMPR, Addressing::Flag_NC, Addressing::Displacement, 8, 12, 0, }, // 30nn: JR NC, e-2
		{ L"LD", Function::LOAD, Addressing::WordReg_SP, Addressing::ImmediateWord, 12, 0, 0, }, // 31nnnn: LD SP, nnnn
		{ L"LD", Function::LOAD_DEC, Addressing::WordReg_HLDRef, Addressing::ByteReg_A, 8, 0, 0, }, // 32: LD (HLD), A
		{ L"INC", Function::INC, Addressing::WordReg_SP, Addressing::None, 8, 0, 0, }, // 33: INC SP
		{ L"INC", Function::INC, Addressing::WordReg_HLRef, Addressing::None, 12, 0, 0, }, // 34: INC (HL)
		{ L"DEC", Function::DEC, Addressing::WordReg_HLRef, Addressing::None, 12, 0, 0, }, // 35: DEC (HL)
		{ L"LD", Function::LOAD, Addressing::WordReg_HLRef, Addressing::ImmediateByte, 12, 0, 0, }, // 36nn: LD (HL), nn
		{ L"SCF", Function::CY_SET, Addressing::None, Addressing::None, 4, 0, 0, }, // 37: SCF
		{ L"JR", Function::JMPR, Addressing::Flag_CY, Addressing::Displacement, 8, 12, 0, }, // 38nn: JR CY, e-2
		{ L"ADD", Function::ADD, Addressing::WordReg_HL, Addressing::WordReg_SP, 8, 0, 0, }, // 39: ADD HL, SP
		{ L"LD", Function::LOAD_DEC, Addressing::ByteReg_A, Addressing::WordReg_HLDRef, 8, 0, 0, }, // 3A: LD A, (HLD)
		{ L"DEC", Function::DEC, Addressing::WordReg_SP, Addressing::None, 8, 0, 0, }, // 3B: DEC SP
		{ L"INC", Function::INC, Addressing::ByteReg_A, Addressing::None, 4, 0, 0, }, // 3C: INC A
		{ L"DEC", Function::DEC, Addressing::ByteReg_A, Addressing::None, 4, 0, 0, }, // 3D: DEC A
		{ L"LD", Function::LOAD, Addressing::ByteReg_A, Addressing::ImmediateByte, 8, 0, 0, }, // 3Enn: LD A, nn
		{ L"CCF", Function::CY_INVERT, Addressing::None, Addressing::None, 4, 0, 0, }, // 3F: CCF
		{ L"LD", Function::LOAD, Addressing::ByteReg_B, Addressing::ByteReg_B, 4, 0, 0, }, // 40: LD B, B
		{ L"LD", Function::LOAD, Addressing::ByteReg_B, Addressing::ByteReg_C, 4, 0, 0, }, // 41: LD B, C
		{ L"LD", Function::LOAD, Addressing::ByteReg_B, Addressing::ByteReg_D, 4, 0, 0, }, // 42: LD B, D
		{ L"LD", Function::LOAD, Addressing::ByteReg_B, Addressing::ByteReg_E, 4, 0, 0, }, // 43: LD B, E
		{ L"LD", Function::LOAD, Addressing::ByteReg_B, Addressing::ByteReg_H, 4, 0, 0, }, // 44: LD B, H
		{ L"LD", Function::LOAD, Addressing::ByteReg_B, Addressing::ByteReg_L, 4, 0, 0, }, // 45: LD B, L
		{ L"LD", Function::LOAD, Addressing::ByteReg_B, Addressing::WordReg_HLRef, 8, 0, 0, }, // 46: LD B, (HL)
		{ L"LD", Function::LOAD, Addressing::ByteReg_B, Addressing::ByteReg_A, 4, 0, 0, }, // 47: LD B, A
		{ L"LD", Function::LOAD, Addressing::ByteReg_C, Addressing::ByteReg_B, 4, 0, 0, }, // 48: LD C, B
		{ L"LD", Function::LOAD, Addressing::ByteReg_C, Addressing::ByteReg_C, 4, 0, 0, }, // 49: LD C, C
		{ L"LD", Function::LOAD, Addressing::ByteReg_C, Addressing::ByteReg_D, 4, 0, 0, }, // 4A: LD C, D
		{ L"LD", Function::LOAD, Addressing::ByteReg_C, Addressing::ByteReg_E, 4, 0, 0, }, // 4B: LD C, E
		{ L"LD", Function::LOAD, Addressing::ByteReg_C, Addressing::ByteReg_H, 4, 0, 0, }, // 4C: LD C, H
		{ L"LD", Function::LOAD, Addressing::ByteReg_C, Addressing::ByteReg_L, 4, 0, 0, }, // 4D: LD C, L
		{ L"LD", Function::LOAD, Addressing::ByteReg_C, Addressing::WordReg_HLRef, 8, 0, 0, }, // 4E: LD C, (HL)
		{ L"LD", Function::LOAD, Addressing::ByteReg_C, Addressing::ByteReg_A, 4, 0, 0, }, // 4F: LD C, A
		{ L"LD", Function::LOAD, Addressing::ByteReg_D, Addressing::ByteReg_B, 4, 0, 0, }, // 50: LD D, B
		{ L"LD", Function::LOAD, Addressing::ByteReg_D, Addressing::ByteReg_C, 4, 0, 0, }, // 51: LD D, C
		{ L"LD", Function::LOAD, Addressing::ByteReg_D, Addressing::ByteReg_D, 4, 0, 0, }, // 52: LD D, D
		{ L"LD", Function::LOAD, Addressing::ByteReg_D, Addressing::ByteReg_E, 4, 0, 0, }, // 53: LD D, E
		{ L"LD", Function::LOAD, Addressing::ByteReg_D, Addressing::ByteReg_H, 4, 0, 0, }, // 54: LD D, H
		{ L"LD", Function::LOAD, Addressing::ByteReg_D, Addressing::ByteReg_L, 4, 0, 0, }, // 55: LD D, L
		{ L"LD", Function::LOAD, Addressing::ByteReg_D, Addressing::WordReg_HLRef, 8, 0, 0, }, // 56: LD D, (HL)
		{ L"LD", Function::LOAD, Addressing::ByteReg_D, Addressing::ByteReg_A, 4, 0, 0, }, // 57: LD D, A
		{ L"LD", Function::LOAD, Addressing::ByteReg_E, Addressing::ByteReg_B, 4, 0, 0, }, // 58: LD E, B
		{ L"LD", Function::LOAD, Addressing::ByteReg_E, Addressing::ByteReg_C, 4, 0, 0, }, // 59: LD E, C
		{ L"LD", Function::LOAD, Addressing::ByteReg_E, Addressing::ByteReg_D, 4, 0, 0, }, // 5A: LD E, D
		{ L"LD", Function::LOAD, Addressing::ByteReg_E, Addressing::ByteReg_E, 4, 0, 0, }, // 5B: LD E, E
		{ L"LD", Function::LOAD, Addressing::ByteReg_E, Addressing::ByteReg_H, 4, 0, 0, }, // 5C: LD E, H
		{ L"LD", Function::LOAD, Addressing::ByteReg_E, Addressing::ByteReg_L, 4, 0, 0, }, // 5D: LD E, L
		{ L"LD", Function::LOAD, Addressing::ByteReg_E, Addressing::WordReg_HLRef, 8, 0, 0, }, // 5E: LD E, (HL)
		{ L"LD", Function::LOAD, Addressing::ByteReg_E, Addressing::ByteReg_A, 4, 0, 0, }, // 5F: LD E, A
		{ L"LD", Function::LOAD, Addressing::ByteReg_H, Addressing::ByteReg_B, 4, 0, 0, }, // 60: LD H, B
		{ L"LD", Function::LOAD, Addressing::ByteReg_H, Addressing::ByteReg_C, 4, 0, 0, }, // 61: LD H, C
		{ L"LD", Function::LOAD, Addressing::ByteReg_H, Addressing::ByteReg_D, 4, 0, 0, }, // 62: LD H, D
		{ L"LD", Function::LOAD, Addressing::ByteReg_H, Addressing::ByteReg_E, 4, 0, 0, }, // 63: LD H, E
		{ L"LD", Function::LOAD, Addressing::ByteReg_H, Addressing::ByteReg_H, 4, 0, 0, }, // 64: LD H, H
		{ L"LD", Function::LOAD, Addressing::ByteReg_H, Addressing::ByteReg_L, 4, 0, 0, }, // 65: LD H, L
		{ L"LD", Function::LOAD, Addressing::ByteReg_H, Addressing::WordReg_HLRef, 8, 0, 0, }, // 66: LD H, (HL)
		{ L"LD", Function::LOAD, Addressing::ByteReg_H, Addressing::ByteReg_A, 4, 0, 0, }, // 67: LD H, A
		{ L"LD", Function::LOAD, Addressing::ByteReg_L, Addressing::ByteReg_B, 4, 0, 0, }, // 68: LD L, B
		{ L"LD", Function::LOAD, Addressing::ByteReg_L, Addressing::ByteReg_C, 4, 0, 0, }, // 69: LD L, C
		{ L"LD", Function::LOAD, Addressing::ByteReg_L, Addressing::ByteReg_D, 4, 0, 0, }, // 6A: LD L, D
		{ L"LD", Function::LOAD, Addressing::ByteReg_L, Addressing::ByteReg_E, 4, 0, 0, }, // 6B: LD L, E
		{ L"LD", Function::LOAD, Addressing::ByteReg_L, Addressing::ByteReg_H, 4, 0, 0, }, // 6C: LD L, H
		{ L"LD", Function::LOAD, Addressing::ByteReg_L, Addressing::ByteReg_L, 4, 0, 0, }, // 6D: LD L, L
		{ L"LD", Function::LOAD, Addressing::ByteReg_L, Addressing::WordReg_HLRef, 8, 0, 0, }, // 6E: LD L, (HL)
		{ L"LD", Function::LOAD, Addressing::ByteReg_L, Addressing::ByteReg_A, 4, 0, 0, }, // 6F: LD L, A
		{ L"LD", Function::LOAD, Addressing::WordReg_HLRef, Addressing::ByteReg_B, 8, 0, 0, }, // 70: LD (HL), B
		{ L"LD", Function::LOAD, Addressing::WordReg_HLRef, Addressing::ByteReg_C, 8, 0, 0, }, // 71: LD (HL), C
		{ L"LD", Function::LOAD, Addressing::WordReg_HLRef, Addressing::ByteReg_D, 8, 0, 0, }, // 72: LD (HL), D
		{ L"LD", Function::LOAD, Addressing::WordReg_HLRef, Addressing::ByteReg_E, 8, 0, 0, }, // 73: LD (HL), E
		{ L"LD", Function::LOAD, Addressing::WordReg_HLRef, Addressing::ByteReg_H, 8, 0, 0, }, // 74: LD (HL), H
		{ L"LD", Function::LOAD, Addressing::WordReg_HLRef, Addressing::ByteReg_L, 8, 0, 0, }, // 75: LD (HL), L
		{ L"HALT", Function::HALT, Addressing::None, Addressing::None, 4, 0, 0, }, // 76: HALT
		{ L"LD", Function::LOAD, Addressing::WordReg_HLRef, Addressing::ByteReg_A, 8, 0, 0, }, // 77: LD (HL), A
		{ L"LD", Function::LOAD, Addressing::ByteReg_A, Addressing::ByteReg_B, 4, 0, 0, }, // 78: LD A, B
		{ L"LD", Function::LOAD, Addressing::ByteReg_A, Addressing::ByteReg_C, 4, 0, 0, }, // 79: LD A, C
		{ L"LD", Function::LOAD, Addressing::ByteReg_A, Addressing::ByteReg_D, 4, 0, 0, }, // 7A: LD A, D
		{ L"LD", Function::LOAD, Addressing::ByteReg_A, Addressing::ByteReg_E, 4, 0, 0, }, // 7B: LD A, E
		{ L"LD", Function::LOAD, Addressing::ByteReg_A, Addressing::ByteReg_H, 4, 0, 0, }, // 7C: LD A, H
		{ L"LD", Function::LOAD, Addressing::ByteReg_A, Addressing::ByteReg_L, 4, 0, 0, }, // 7D: LD A, L
		{ L"LD", Function::LOAD, Addressing::ByteReg_A, Addressing::WordReg_HLRef, 8, 0, 0, }, // 7E: LD A, (HL)
		{ L"LD", Function::LOAD, Addressing::ByteReg_A, Addressing::ByteReg_A, 4, 0, 0, }, // 7F: LD A, A
		{ L"ADD", Function::ADD, Addressing::ByteReg_A, Addressing::ByteReg_B, 4, 0, 0, }, // 80: ADD A, B
		{ L"ADD", Function::ADD, Addressing::ByteReg_A, Addressing::ByteReg_C, 4, 0, 0, }, // 81: ADD A, C
		{ L"ADD", Function::ADD, Addressing::ByteReg_A, Addressing::ByteReg_D, 4, 0, 0, }, // 82: ADD A, D
		{ L"ADD", Function::ADD, Addressing::ByteReg_A, Addressing::ByteReg_E, 4, 0, 0, }, // 83: ADD A, E
		{ L"ADD", Function::ADD, Addressing::ByteReg_A, Addressing::ByteReg_H, 4, 0, 0, }, // 84: ADD A, H
		{ L"ADD", Function::ADD, Addressing::ByteReg_A, Addressing::ByteReg_L, 4, 0, 0, }, // 85: ADD A, L
		{ L"ADD", Function::ADD, Addressing::ByteReg_A, Addressing::WordReg_HLRef, 8, 0, 0, }, // 86: ADD A, (HL)
		{ L"ADD", Function::ADD, Addressing::ByteReg_A, Addressing::ByteReg_A, 4, 0, 0, }, // 87: ADD A, A
		{ L"ADC", Function::ADD_CY, Addressing::ByteReg_A, Addressing::ByteReg_B, 4, 0, 0, }, // 88: ADC A, B
		{ L"ADC", Function::ADD_CY, Addressing::ByteReg_A, Addressing::ByteReg_C, 4, 0, 0, }, // 89: ADC A, C
		{ L"ADC", Function::ADD_CY, Addressing::ByteReg_A, Addressing::ByteReg_D, 4, 0, 0, }, // 8A: ADC A, D
		{ L"ADC", Function::ADD_CY, Addressing::ByteReg_A, Addressing::ByteReg_E, 4, 0, 0, }, // 8B: ADC A, E
		{ L"ADC", Function::ADD_CY, Addressing::ByteReg_A, Addressing::ByteReg_H, 4, 0, 0, }, // 8C: ADC A, H
		{ L"ADC", Function::ADD_CY, Addressing::ByteReg_A, Addressing::ByteReg_L, 4, 0, 0, }, // 8D: ADC A, L
		{ L"ADC", Function::ADD_CY, Addressing::ByteReg_A, Addressing::WordReg_HLRef, 8, 0, 0, }, // 8E: ADC A, (HL)
		{ L"ADC", Function::ADD_CY, Addressing::ByteReg_A, Addressing::ByteReg_A, 4, 0, 0, }, // 8F: ADC A, A
		{ L"SUB", Function::SUB, Addressing::ByteReg_A, Addressing::ByteReg_B, 4, 0, 0, }, // 90: SUB |A, B
		{ L"SUB", Function::SUB, Addressing::ByteReg_A, Addressing::ByteReg_C, 4, 0, 0, }, // 91: SUB |A, C
		{ L"SUB", Function::SUB, Addressing::ByteReg_A, Addressing::ByteReg_D, 4, 0, 0, }, // 92: SUB |A, D
		{ L"SUB", Function::SUB, Addressing::ByteReg_A, Addressing::ByteReg_E, 4, 0, 0, }, // 93: SUB |A, E
		{ L"SUB", Function::SUB, Addressing::ByteReg_A, Addressing::ByteReg_H, 4, 0, 0, }, // 94: SUB |A, H
		{ L"SUB", Function::SUB, Addressing::ByteReg_A, Addressing::ByteReg_L, 4, 0, 0, }, // 95: SUB |A, L
		{ L"SUB", Function::SUB, Addressing::ByteReg_A, Addressing::WordReg_HLRef, 8, 0, 0, }, // 96: SUB |A, (HL)
		{ L"SUB", Function::SUB, Addressing::ByteReg_A, Addressing::ByteReg_A, 4, 0, 0, }, // 97: SUB |A, A
		{ L"SBC", Function::SUB_CY, Addressing::ByteReg_A, Addressing::ByteReg_B, 4, 0, 0, }, // 98: SBC A, B
		{ L"SBC", Function::SUB_CY, Addressing::ByteReg_A, Addressing::ByteReg_C, 4, 0, 0, }, // 99: SBC A, C
		{ L"SBC", Function::SUB_CY, Addressing::ByteReg_A, Addressing::ByteReg_D, 4, 0, 0, }, // 9A: SBC A, D
		{ L"SBC", Function::SUB_CY, Addressing::ByteReg_A, Addressing::ByteReg_E, 4, 0, 0, }, // 9B: SBC A, E
		{ L"SBC", Function::SUB_CY, Addressing::ByteReg_A, Addressing::ByteReg_H, 4, 0, 0, }, // 9C: SBC A, H
		{ L"SBC", Function::SUB_CY, Addressing::ByteReg_A, Addressing::ByteReg_L, 4, 0, 0, }, // 9D: SBC A, L
		{ L"SBC", Function::SUB_CY, Addressing::ByteReg_A, Addressing::WordReg_HLRef, 8, 0, 0, }, // 9E: SBC A, (HL)
		{ L"SBC", Function::SUB_CY, Addressing::ByteReg_A, Addressing::ByteReg_A, 4, 0, 0, }, // 9F: SBC A, A
		{ L"AND", Function::AND, Addressing::ByteReg_A, Addressing::ByteReg_B, 4, 0, 0, }, // A0: AND |A, B
		{ L"AND", Function::AND, Addressing::ByteReg_A, Addressing::ByteReg_C, 4, 0, 0, }, // A1: AND |A, C
		{ L"AND", Function::AND, Addressing::ByteReg_A, Addressing::ByteReg_D, 4, 0, 0, }, // A2: AND |A, D
		{ L"AND", Function::AND, Addressing::ByteReg_A, Addressing::ByteReg_E, 4, 0, 0, }, // A3: AND |A, E
		{ L"AND", Function::AND, Addressing::ByteReg_A, Addressing::ByteReg_H, 4, 0, 0, }, // A4: AND |A, H
		{ L"AND", Function::AND, Addressing::ByteReg_A, Addressing::ByteReg_L, 4, 0, 0, }, // A5: AND |A, L
		{ L"AND", Function::AND, Addressing::ByteReg_A, Addressing::WordReg_HLRef, 8, 0, 0, }, // A6: AND |A, (HL)
		{ L"AND", Function::AND, Addressing::ByteReg_A, Addressing::ByteReg_A, 4, 0, 0, }, // A7: AND |A, A
		{ L"XOR", Function::XOR, Addressing::ByteReg_A, Addressing::ByteReg_B, 4, 0, 0, }, // A8: XOR A, B
		{ L"XOR", Function::XOR, Addressing::ByteReg_A, Addressing::ByteReg_C, 4, 0, 0, }, // A9: XOR A, C
		{ L"XOR", Function::XOR, Addressing::ByteReg_A, Addressing::ByteReg_D, 4, 0, 0, }, // AA: XOR A, D
		{ L"XOR", Function::XOR, Addressing::ByteReg_A, Addressing::ByteReg_E, 4, 0, 0, }, // AB: XOR A, E
		{ L"XOR", Function::XOR, Addressing::ByteReg_A, Addressing::ByteReg_H, 4, 0, 0, }, // AC: XOR A, H
		{ L"XOR", Function::XOR, Addressing::ByteReg_A, Addressing::ByteReg_L, 4, 0, 0, }, // AD: XOR A, L
		{ L"XOR", Function::XOR, Addressing::ByteReg_A, Addressing::WordReg_HLRef, 8, 0, 0, }, // AE: XOR A, (HL)
		{ L"XOR", Function::XOR, Addressing::ByteReg_A, Addressing::ByteReg_A, 4, 0, 0, }, // AF: XOR A, A
		{ L"OR", Function::OR, Addressing::ByteReg_A, Addressing::ByteReg_B, 4, 0, 0, }, // B0: OR |A, B
		{ L"OR", Function::OR, Addressing::ByteReg_A, Addressing::ByteReg_C, 4, 0, 0, }, // B1: OR |A, C
		{ L"OR", Function::OR, Addressing::ByteReg_A, Addressing::ByteReg_D, 4, 0, 0, }, // B2: OR |A, D
		{ L"OR", Function::OR, Addressing::ByteReg_A, Addressing::ByteReg_E, 4, 0, 0, }, // B3: OR |A, E
		{ L"OR", Function::OR, Addressing::ByteReg_A, Addressing::ByteReg_H, 4, 0, 0, }, // B4: OR |A, H
		{ L"OR", Function::OR, Addressing::ByteReg_A, Addressing::ByteReg_L, 4, 0, 0, }, // B5: OR |A, L
		{ L"OR", Function::OR, Addressing::ByteReg_A, Addressing::WordReg_HLRef, 8, 0, 0, }, // B6: OR |A, (HL)
		{ L"OR", Function::OR, Addressing::ByteReg_A, Addressing::ByteReg_A, 4, 0, 0, }, // B7: OR |A, A
		{ L"CP", Function::CMP, Addressing::ByteReg_A, Addressing::ByteReg_B, 4, 0, 0, }, // B8: CP |A, B
		{ L"CP", Function::CMP, Addressing::ByteReg_A, Addressing::ByteReg_C, 4, 0, 0, }, // B9: CP |A, C
		{ L"CP", Function::CMP, Addressing::ByteReg_A, Addressing::ByteReg_D, 4, 0, 0, }, // BA: CP |A, D
		{ L"CP", Function::CMP, Addressing::ByteReg_A, Addressing::ByteReg_E, 4, 0, 0, }, // BB: CP |A, E
		{ L"CP", Function::CMP, Addressing::ByteReg_A, Addressing::ByteReg_H, 4, 0, 0, }, // BC: CP |A, H
		{ L"CP", Function::CMP, Addressing::ByteReg_A, Addressing::ByteReg_L, 4, 0, 0, }, // BD: CP |A, L
		{ L"CP", Function::CMP, Addressing::ByteReg_A, Addressing::WordReg_HLRef, 8, 0, 0, }, // BE: CP |A, (HL)
		{ L"CP", Function::CMP, Addressing::ByteReg_A, Addressing::ByteReg_A, 4, 0, 0, }, // BF: CP |A, A
		{ L"RET", Function::RET, Addressing::Flag_NZ, Addressing::None, 8, 20, 0, }, // C0: RET NZ
		{ L"POP", Function::POP, Addressing::WordReg_BC, Addressing::None, 12, 0, 0, }, // C1: POP BC
		{ L"JP", Function::JMP, Addressing::Flag_NZ, Addressing::Address, 12, 16, 0, }, // C2nnnn: JP NZ, nnnn
		{ L"JP", Function::JMP, Addressing::Address, Addressing::None, 16, 0, 0, }, // C3nnnn: JP nnnn
		{ L"CALL", Function::CALL, Addressing::Flag_NZ, Addressing::Address, 12, 24, 0, }, // C4nnnn: CALL NZ, nnnn
		{ L"PUSH", Function::PUSH, Addressing::WordReg_BC, Addressing::None, 16, 0, 0, }, // C5: PUSH BC
		{ L"ADD", Function::ADD, Addressing::ByteReg_A, Addressing::ImmediateByte, 8, 0, 0, }, // C6nn: ADD A, nn
		{ L"RST", Function::RST, Addressing::Rst00, Addressing::None, 16, 0, 0, }, // C7: RST 00h
		{ L"RET", Function::RET, Addressing::Flag_Z, Addressing::None, 8, 20, 0, }, // C8: RET Z
		{ L"RET", Function::RET, Addressing::None, Addressing::None, 16, 0, 0, }, // C9: RET
		{ L"JP", Function::JMP, Addressing::Flag_Z, Addressing::Address, 12, 16, 0, }, // CAnnnn: JP Z, nnnn
		{ L"", Function::PREFIX, Addressing::None, Addressing::None, 0, 0, 0, }, // CB: 
		{ L"CALL", Function::CALL, Addressing::Flag_Z, Addressing::Address, 12, 24, 0, }, // CCnnnn: CALL Z, nnnn
		{ L"CALL", Function::CALL, Addressing::Address, Addressing::None, 24, 0, 0, }, // CDnnnn: CALL nnnn
		{ L"ADC", Function::ADD_CY, Addressing::ByteReg_A, Addressing::ImmediateByte, 8, 0, 0, }, // CEnn: ADC A, nn
		{ L"RST", Function::RST, Addressing::Rst08, Addressing::None, 16, 0, 0, }, // CF: RST 08h
		{ L"RET", Function::RET, Addressing::Flag_NC, Addressing::None, 8, 20, 0, }, // D0: RET NC
		{ L"POP", Function::POP, Addressing::WordReg_DE, Addressing::None, 12, 0, 0, }, // D1: POP DE
		{ L"JP", Function::JMP, Addressing::Flag_NC, Addressing::Address, 12, 16, 0, }, // D2nnnn: JP NC, nnnn
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // D3: ???
		{ L"CALL", Function::CALL, Addressing::Flag_NC, Addressing::Address, 12, 24, 0, }, // D4nnnn: CALL NC, nnnn
		{ L"PUSH", Function::PUSH, Addressing::WordReg_DE, Addressing::None, 16, 0, 0, }, // D5: PUSH DE
		{ L"SUB", Function::SUB, Addressing::ByteReg_A, Addressing::ImmediateByte, 8, 0, 0, }, // D6nn: SUB |A, nn
		{ L"RST", Function::RST, Addressing::Rst10, Addressing::None, 16, 0, 0, }, // D7: RST 10h
		{ L"RET", Function::RET, Addressing::Flag_CY, Addressing::None, 8, 20, 0, }, // D8: RET CY
		{ L"RETI", Function::RETI, Addressing::None, Addressing::None, 16, 0, 0, }, // D9: RETI
		{ L"JP", Function::JMP, Addressing::Flag_CY, Addressing::Address, 12, 16, 0, }, // DAnnnn: JP CY, nnnn
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // DB: ???
		{ L"CALL", Function::CALL, Addressing::Flag_CY, Addressing::Address, 12, 24, 0, }, // DCnnnn: CALL CY, nnnn
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // DD: ???
		{ L"SBC", Function::SUB_CY, Addressing::ByteReg_A, Addressing::ImmediateByte, 8, 0, 0, }, // DEnn: SBC A, nn
		{ L"RST", Function::RST, Addressing::Rst18, Addressing::None, 16, 0, 0, }, // DF: RST 18h
		{ L"LD", Function::LOAD_HIGH, Addressing::HighRefPlusImmediateByte, Addressing::ByteReg_A, 12, 0, 0, }, // E0nn: LD ($ff00 + nn), A
		{ L"POP", Function::POP, Addressing::WordReg_HL, Addressing::None, 12, 0, 0, }, // E1: POP HL
		{ L"LD", Function::LOAD_HIGH, Addressing::HighRefPlusByteReg_C, Addressing::ByteReg_A, 8, 0, 0, }, // E2: LD ($ff00 + C), A
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // E3: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // E4: ???
		{ L"PUSH", Function::PUSH, Addressing::WordReg_HL, Addressing::None, 16, 0, 0, }, // E5: PUSH HL
		{ L"AND", Function::AND, Addressing::ByteReg_A, Addressing::ImmediateByte, 8, 0, 0, }, // E6nn: AND |A, nn
		{ L"RST", Function::RST, Addressing::Rst20, Addressing::None, 16, 0, 0, }, // E7: RST 20h
		{ L"ADD", Function::ADD, Addressing::WordReg_SP, Addressing::ImmediateByte, 16, 0, 0, }, // E8nn: ADD SP, nn
		{ L"JP", Function::JMP, Addressing::WordReg_HL, Addressing::None, 4, 0, 0, }, // E9: JP HL
		{ L"LD", Function::LOAD, Addressing::AddressByteRef, Addressing::ByteReg_A, 16, 0, 0, }, // EAnnnn: LD (nnnn), A
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EB: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // EC: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // ED: ???
		{ L"XOR", Function::XOR, Addressing::ByteReg_A, Addressing::ImmediateByte, 8, 0, 0, }, // EEnn: XOR A, nn
		{ L"RST", Function::RST, Addressing::Rst28, Addressing::None, 16, 0, 0, }, // EF: RST 28h
		{ L"LD", Function::LOAD_HIGH, Addressing::ByteReg_A, Addressing::HighRefPlusImmediateByte, 12, 0, 0, }, // F0nn: LD A, ($ff00 + nn)
		{ L"POP", Function::POP, Addressing::WordReg_AF, Addressing::None, 12, 0, 0, }, // F1: POP AF
		{ L"LD", Function::LOAD_HIGH, Addressing::ByteReg_A, Addressing::HighRefPlusByteReg_C, 8, 0, 0, }, // F2: LD A, ($ff00 + C)
		{ L"DI", Function::DI, Addressing::None, Addressing::None, 4, 0, 0, }, // F3: DI
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // F4: ???
		{ L"PUSH", Function::PUSH, Addressing::WordReg_AF, Addressing::None, 16, 0, 0, }, // F5: PUSH AF
		{ L"OR", Function::OR, Addressing::ByteReg_A, Addressing::ImmediateByte, 8, 0, 0, }, // F6nn: OR |A, nn
		{ L"RST", Function::RST, Addressing::Rst30, Addressing::None, 16, 0, 0, }, // F7: RST 30h
		{ L"LD", Function::LOAD_SP, Addressing::WordReg_HL, Addressing::SPPlusImmediateByte, 12, 0, 0, }, // F8nn: LD HL, SP + nn
		{ L"LD", Function::LOAD, Addressing::WordReg_SP, Addressing::WordReg_HL, 8, 0, 0, }, // F9: LD SP, HL
		{ L"LD", Function::LOAD, Addressing::ByteReg_A, Addressing::AddressByteRef, 16, 0, 0, }, // FAnnnn: LD A, (nnnn)
		{ L"EI", Function::EI, Addressing::None, Addressing::None, 4, 0, 0, }, // FB: EI
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // FC: ???
		{ L"???", Function::NOP, Addressing::None, Addressing::None, 4, 0, 0}, // FD: ???
		{ L"CP", Function::CMP, Addressing::ByteReg_A, Addressing::ImmediateByte, 8, 0, 0, }, // FEnn: CP |A, nn
		{ L"RST", Function::RST, Addressing::Rst38, Addressing::None, 16, 0, 0, }, // FF: RST 38h
    };

    OpcodeEntry ExtenededOpcodes[0x100] =
    {
    };

    OpcodeEntry BitOpcodes[0x100] =
    {
		{ L"RLC", Function::RL, Addressing::ByteReg_B, Addressing::None, 8, 0, 0, }, // CB00: RLC B
		{ L"RLC", Function::RL, Addressing::ByteReg_C, Addressing::None, 8, 0, 0, }, // CB01: RLC C
		{ L"RLC", Function::RL, Addressing::ByteReg_D, Addressing::None, 8, 0, 0, }, // CB02: RLC D
		{ L"RLC", Function::RL, Addressing::ByteReg_E, Addressing::None, 8, 0, 0, }, // CB03: RLC E
		{ L"RLC", Function::RL, Addressing::ByteReg_H, Addressing::None, 8, 0, 0, }, // CB04: RLC H
		{ L"RLC", Function::RL, Addressing::ByteReg_L, Addressing::None, 8, 0, 0, }, // CB05: RLC L
		{ L"RLC", Function::RL, Addressing::WordReg_HLRef, Addressing::None, 16, 0, 0, }, // CB06: RLC (HL)
		{ L"RLC", Function::RL, Addressing::ByteReg_A, Addressing::None, 8, 0, 0, }, // CB07: RLC A
		{ L"RRC", Function::RR, Addressing::ByteReg_B, Addressing::None, 8, 0, 0, }, // CB08: RRC B
		{ L"RRC", Function::RR, Addressing::ByteReg_C, Addressing::None, 8, 0, 0, }, // CB09: RRC C
		{ L"RRC", Function::RR, Addressing::ByteReg_D, Addressing::None, 8, 0, 0, }, // CB0A: RRC D
		{ L"RRC", Function::RR, Addressing::ByteReg_E, Addressing::None, 8, 0, 0, }, // CB0B: RRC E
		{ L"RRC", Function::RR, Addressing::ByteReg_H, Addressing::None, 8, 0, 0, }, // CB0C: RRC H
		{ L"RRC", Function::RR, Addressing::ByteReg_L, Addressing::None, 8, 0, 0, }, // CB0D: RRC L
		{ L"RRC", Function::RR, Addressing::WordReg_HLRef, Addressing::None, 16, 0, 0, }, // CB0E: RRC (HL)
		{ L"RRC", Function::RR, Addressing::ByteReg_A, Addressing::None, 8, 0, 0, }, // CB0F: RRC A
		{ L"RL", Function::RL_CY, Addressing::ByteReg_B, Addressing::None, 8, 0, 0, }, // CB10: RL B
		{ L"RL", Function::RL_CY, Addressing::ByteReg_C, Addressing::None, 8, 0, 0, }, // CB11: RL C
		{ L"RL", Function::RL_CY, Addressing::ByteReg_D, Addressing::None, 8, 0, 0, }, // CB12: RL D
		{ L"RL", Function::RL_CY, Addressing::ByteReg_E, Addressing::None, 8, 0, 0, }, // CB13: RL E
		{ L"RL", Function::RL_CY, Addressing::ByteReg_H, Addressing::None, 8, 0, 0, }, // CB14: RL H
		{ L"RL", Function::RL_CY, Addressing::ByteReg_L, Addressing::None, 8, 0, 0, }, // CB15: RL L
		{ L"RL", Function::RL_CY, Addressing::WordReg_HLRef, Addressing::None, 16, 0, 0, }, // CB16: RL (HL)
		{ L"RL", Function::RL_CY, Addressing::ByteReg_A, Addressing::None, 8, 0, 0, }, // CB17: RL A
		{ L"RR", Function::RR_CY, Addressing::ByteReg_B, Addressing::None, 8, 0, 0, }, // CB18: RR B
		{ L"RR", Function::RR_CY, Addressing::ByteReg_C, Addressing::None, 8, 0, 0, }, // CB19: RR C
		{ L"RR", Function::RR_CY, Addressing::ByteReg_D, Addressing::None, 8, 0, 0, }, // CB1A: RR D
		{ L"RR", Function::RR_CY, Addressing::ByteReg_E, Addressing::None, 8, 0, 0, }, // CB1B: RR E
		{ L"RR", Function::RR_CY, Addressing::ByteReg_H, Addressing::None, 8, 0, 0, }, // CB1C: RR H
		{ L"RR", Function::RR_CY, Addressing::ByteReg_L, Addressing::None, 8, 0, 0, }, // CB1D: RR L
		{ L"RR", Function::RR_CY, Addressing::WordReg_HLRef, Addressing::None, 16, 0, 0, }, // CB1E: RR (HL)
		{ L"RR", Function::RR_CY, Addressing::ByteReg_A, Addressing::None, 8, 0, 0, }, // CB1F: RR A
		{ L"SLA", Function::SL_SIGNED, Addressing::ByteReg_B, Addressing::None, 8, 0, 0, }, // CB20: SLA B
		{ L"SLA", Function::SL_SIGNED, Addressing::ByteReg_C, Addressing::None, 8, 0, 0, }, // CB21: SLA C
		{ L"SLA", Function::SL_SIGNED, Addressing::ByteReg_D, Addressing::None, 8, 0, 0, }, // CB22: SLA D
		{ L"SLA", Function::SL_SIGNED, Addressing::ByteReg_E, Addressing::None, 8, 0, 0, }, // CB23: SLA E
		{ L"SLA", Function::SL_SIGNED, Addressing::ByteReg_H, Addressing::None, 8, 0, 0, }, // CB24: SLA H
		{ L"SLA", Function::SL_SIGNED, Addressing::ByteReg_L, Addressing::None, 8, 0, 0, }, // CB25: SLA L
		{ L"SLA", Function::SL_SIGNED, Addressing::WordReg_HLRef, Addressing::None, 16, 0, 0, }, // CB26: SLA (HL)
		{ L"SLA", Function::SL_SIGNED, Addressing::ByteReg_A, Addressing::None, 8, 0, 0, }, // CB27: SLA A
		{ L"SRA", Function::SR_SIGNED, Addressing::ByteReg_B, Addressing::None, 8, 0, 0, }, // CB28: SRA B
		{ L"SRA", Function::SR_SIGNED, Addressing::ByteReg_C, Addressing::None, 8, 0, 0, }, // CB29: SRA C
		{ L"SRA", Function::SR_SIGNED, Addressing::ByteReg_D, Addressing::None, 8, 0, 0, }, // CB2A: SRA D
		{ L"SRA", Function::SR_SIGNED, Addressing::ByteReg_E, Addressing::None, 8, 0, 0, }, // CB2B: SRA E
		{ L"SRA", Function::SR_SIGNED, Addressing::ByteReg_H, Addressing::None, 8, 0, 0, }, // CB2C: SRA H
		{ L"SRA", Function::SR_SIGNED, Addressing::ByteReg_L, Addressing::None, 8, 0, 0, }, // CB2D: SRA L
		{ L"SRA", Function::SR_SIGNED, Addressing::WordReg_HLRef, Addressing::None, 16, 0, 0, }, // CB2E: SRA (HL)
		{ L"SRA", Function::SR_SIGNED, Addressing::ByteReg_A, Addressing::None, 8, 0, 0, }, // CB2F: SRA A
		{ L"SWAP", Function::SWAP, Addressing::ByteReg_B, Addressing::None, 8, 0, 0, }, // CB30: *SWAP B
		{ L"SWAP", Function::SWAP, Addressing::ByteReg_C, Addressing::None, 8, 0, 0, }, // CB31: *SWAP C
		{ L"SWAP", Function::SWAP, Addressing::ByteReg_D, Addressing::None, 8, 0, 0, }, // CB32: *SWAP D
		{ L"SWAP", Function::SWAP, Addressing::ByteReg_E, Addressing::None, 8, 0, 0, }, // CB33: *SWAP E
		{ L"SWAP", Function::SWAP, Addressing::ByteReg_H, Addressing::None, 8, 0, 0, }, // CB34: *SWAP H
		{ L"SWAP", Function::SWAP, Addressing::ByteReg_L, Addressing::None, 8, 0, 0, }, // CB35: *SWAP L
		{ L"SWAP", Function::SWAP, Addressing::WordReg_HLRef, Addressing::None, 16, 0, 0, }, // CB36: *SWAP (HL)
		{ L"SWAP", Function::SWAP, Addressing::ByteReg_A, Addressing::None, 8, 0, 0, }, // CB37: *SWAP A
		{ L"SRL", Function::SR_L, Addressing::ByteReg_B, Addressing::None, 8, 0, 0, }, // CB38: SRL B
		{ L"SRL", Function::SR_L, Addressing::ByteReg_C, Addressing::None, 8, 0, 0, }, // CB39: SRL C
		{ L"SRL", Function::SR_L, Addressing::ByteReg_D, Addressing::None, 8, 0, 0, }, // CB3A: SRL D
		{ L"SRL", Function::SR_L, Addressing::ByteReg_E, Addressing::None, 8, 0, 0, }, // CB3B: SRL E
		{ L"SRL", Function::SR_L, Addressing::ByteReg_H, Addressing::None, 8, 0, 0, }, // CB3C: SRL H
		{ L"SRL", Function::SR_L, Addressing::ByteReg_L, Addressing::None, 8, 0, 0, }, // CB3D: SRL L
		{ L"SRL", Function::SR_L, Addressing::WordReg_HLRef, Addressing::None, 16, 0, 0, }, // CB3E: SRL (HL)
		{ L"SRL", Function::SR_L, Addressing::ByteReg_A, Addressing::None, 8, 0, 0, }, // CB3F: SRL A
		{ L"BIT", Function::BIT, Addressing::Value0, Addressing::ByteReg_B, 8, 0, 0, }, // CB40: BIT 0, B
		{ L"BIT", Function::BIT, Addressing::Value0, Addressing::ByteReg_C, 8, 0, 0, }, // CB41: BIT 0, C
		{ L"BIT", Function::BIT, Addressing::Value0, Addressing::ByteReg_D, 8, 0, 0, }, // CB42: BIT 0, D
		{ L"BIT", Function::BIT, Addressing::Value0, Addressing::ByteReg_E, 8, 0, 0, }, // CB43: BIT 0, E
		{ L"BIT", Function::BIT, Addressing::Value0, Addressing::ByteReg_H, 8, 0, 0, }, // CB44: BIT 0, H
		{ L"BIT", Function::BIT, Addressing::Value0, Addressing::ByteReg_L, 8, 0, 0, }, // CB45: BIT 0, L
		{ L"BIT", Function::BIT, Addressing::Value0, Addressing::WordReg_HLRef, 16, 0, 0, }, // CB46: BIT 0, (HL)
		{ L"BIT", Function::BIT, Addressing::Value0, Addressing::ByteReg_A, 8, 0, 0, }, // CB47: BIT 0, A
		{ L"BIT", Function::BIT, Addressing::Value1, Addressing::ByteReg_B, 8, 0, 0, }, // CB48: BIT 1, B
		{ L"BIT", Function::BIT, Addressing::Value1, Addressing::ByteReg_C, 8, 0, 0, }, // CB49: BIT 1, C
		{ L"BIT", Function::BIT, Addressing::Value1, Addressing::ByteReg_D, 8, 0, 0, }, // CB4A: BIT 1, D
		{ L"BIT", Function::BIT, Addressing::Value1, Addressing::ByteReg_E, 8, 0, 0, }, // CB4B: BIT 1, E
		{ L"BIT", Function::BIT, Addressing::Value1, Addressing::ByteReg_H, 8, 0, 0, }, // CB4C: BIT 1, H
		{ L"BIT", Function::BIT, Addressing::Value1, Addressing::ByteReg_L, 8, 0, 0, }, // CB4D: BIT 1, L
		{ L"BIT", Function::BIT, Addressing::Value1, Addressing::WordReg_HLRef, 16, 0, 0, }, // CB4E: BIT 1, (HL)
		{ L"BIT", Function::BIT, Addressing::Value1, Addressing::ByteReg_A, 8, 0, 0, }, // CB4F: BIT 1, A
		{ L"BIT", Function::BIT, Addressing::Value2, Addressing::ByteReg_B, 8, 0, 0, }, // CB50: BIT 2, B
		{ L"BIT", Function::BIT, Addressing::Value2, Addressing::ByteReg_C, 8, 0, 0, }, // CB51: BIT 2, C
		{ L"BIT", Function::BIT, Addressing::Value2, Addressing::ByteReg_D, 8, 0, 0, }, // CB52: BIT 2, D
		{ L"BIT", Function::BIT, Addressing::Value2, Addressing::ByteReg_E, 8, 0, 0, }, // CB53: BIT 2, E
		{ L"BIT", Function::BIT, Addressing::Value2, Addressing::ByteReg_H, 8, 0, 0, }, // CB54: BIT 2, H
		{ L"BIT", Function::BIT, Addressing::Value2, Addressing::ByteReg_L, 8, 0, 0, }, // CB55: BIT 2, L
		{ L"BIT", Function::BIT, Addressing::Value2, Addressing::WordReg_HLRef, 16, 0, 0, }, // CB56: BIT 2, (HL)
		{ L"BIT", Function::BIT, Addressing::Value2, Addressing::ByteReg_A, 8, 0, 0, }, // CB57: BIT 2, A
		{ L"BIT", Function::BIT, Addressing::Value3, Addressing::ByteReg_B, 8, 0, 0, }, // CB58: BIT 3, B
		{ L"BIT", Function::BIT, Addressing::Value3, Addressing::ByteReg_C, 8, 0, 0, }, // CB59: BIT 3, C
		{ L"BIT", Function::BIT, Addressing::Value3, Addressing::ByteReg_D, 8, 0, 0, }, // CB5A: BIT 3, D
		{ L"BIT", Function::BIT, Addressing::Value3, Addressing::ByteReg_E, 8, 0, 0, }, // CB5B: BIT 3, E
		{ L"BIT", Function::BIT, Addressing::Value3, Addressing::ByteReg_H, 8, 0, 0, }, // CB5C: BIT 3, H
		{ L"BIT", Function::BIT, Addressing::Value3, Addressing::ByteReg_L, 8, 0, 0, }, // CB5D: BIT 3, L
		{ L"BIT", Function::BIT, Addressing::Value3, Addressing::WordReg_HLRef, 16, 0, 0, }, // CB5E: BIT 3, (HL)
		{ L"BIT", Function::BIT, Addressing::Value3, Addressing::ByteReg_A, 8, 0, 0, }, // CB5F: BIT 3, A
		{ L"BIT", Function::BIT, Addressing::Value4, Addressing::ByteReg_B, 8, 0, 0, }, // CB60: BIT 4, B
		{ L"BIT", Function::BIT, Addressing::Value4, Addressing::ByteReg_C, 8, 0, 0, }, // CB61: BIT 4, C
		{ L"BIT", Function::BIT, Addressing::Value4, Addressing::ByteReg_D, 8, 0, 0, }, // CB62: BIT 4, D
		{ L"BIT", Function::BIT, Addressing::Value4, Addressing::ByteReg_E, 8, 0, 0, }, // CB63: BIT 4, E
		{ L"BIT", Function::BIT, Addressing::Value4, Addressing::ByteReg_H, 8, 0, 0, }, // CB64: BIT 4, H
		{ L"BIT", Function::BIT, Addressing::Value4, Addressing::ByteReg_L, 8, 0, 0, }, // CB65: BIT 4, L
		{ L"BIT", Function::BIT, Addressing::Value4, Addressing::WordReg_HLRef, 16, 0, 0, }, // CB66: BIT 4, (HL)
		{ L"BIT", Function::BIT, Addressing::Value4, Addressing::ByteReg_A, 8, 0, 0, }, // CB67: BIT 4, A
		{ L"BIT", Function::BIT, Addressing::Value5, Addressing::ByteReg_B, 8, 0, 0, }, // CB68: BIT 5, B
		{ L"BIT", Function::BIT, Addressing::Value5, Addressing::ByteReg_C, 8, 0, 0, }, // CB69: BIT 5, C
		{ L"BIT", Function::BIT, Addressing::Value5, Addressing::ByteReg_D, 8, 0, 0, }, // CB6A: BIT 5, D
		{ L"BIT", Function::BIT, Addressing::Value5, Addressing::ByteReg_E, 8, 0, 0, }, // CB6B: BIT 5, E
		{ L"BIT", Function::BIT, Addressing::Value5, Addressing::ByteReg_H, 8, 0, 0, }, // CB6C: BIT 5, H
		{ L"BIT", Function::BIT, Addressing::Value5, Addressing::ByteReg_L, 8, 0, 0, }, // CB6D: BIT 5, L
		{ L"BIT", Function::BIT, Addressing::Value5, Addressing::WordReg_HLRef, 16, 0, 0, }, // CB6E: BIT 5, (HL)
		{ L"BIT", Function::BIT, Addressing::Value5, Addressing::ByteReg_A, 8, 0, 0, }, // CB6F: BIT 5, A
		{ L"BIT", Function::BIT, Addressing::Value6, Addressing::ByteReg_B, 8, 0, 0, }, // CB70: BIT 6, B
		{ L"BIT", Function::BIT, Addressing::Value6, Addressing::ByteReg_C, 8, 0, 0, }, // CB71: BIT 6, C
		{ L"BIT", Function::BIT, Addressing::Value6, Addressing::ByteReg_D, 8, 0, 0, }, // CB72: BIT 6, D
		{ L"BIT", Function::BIT, Addressing::Value6, Addressing::ByteReg_E, 8, 0, 0, }, // CB73: BIT 6, E
		{ L"BIT", Function::BIT, Addressing::Value6, Addressing::ByteReg_H, 8, 0, 0, }, // CB74: BIT 6, H
		{ L"BIT", Function::BIT, Addressing::Value6, Addressing::ByteReg_L, 8, 0, 0, }, // CB75: BIT 6, L
		{ L"BIT", Function::BIT, Addressing::Value6, Addressing::WordReg_HLRef, 16, 0, 0, }, // CB76: BIT 6, (HL)
		{ L"BIT", Function::BIT, Addressing::Value6, Addressing::ByteReg_A, 8, 0, 0, }, // CB77: BIT 6, A
		{ L"BIT", Function::BIT, Addressing::Value7, Addressing::ByteReg_B, 8, 0, 0, }, // CB78: BIT 7, B
		{ L"BIT", Function::BIT, Addressing::Value7, Addressing::ByteReg_C, 8, 0, 0, }, // CB79: BIT 7, C
		{ L"BIT", Function::BIT, Addressing::Value7, Addressing::ByteReg_D, 8, 0, 0, }, // CB7A: BIT 7, D
		{ L"BIT", Function::BIT, Addressing::Value7, Addressing::ByteReg_E, 8, 0, 0, }, // CB7B: BIT 7, E
		{ L"BIT", Function::BIT, Addressing::Value7, Addressing::ByteReg_H, 8, 0, 0, }, // CB7C: BIT 7, H
		{ L"BIT", Function::BIT, Addressing::Value7, Addressing::ByteReg_L, 8, 0, 0, }, // CB7D: BIT 7, L
		{ L"BIT", Function::BIT, Addressing::Value7, Addressing::WordReg_HLRef, 16, 0, 0, }, // CB7E: BIT 7, (HL)
		{ L"BIT", Function::BIT, Addressing::Value7, Addressing::ByteReg_A, 8, 0, 0, }, // CB7F: BIT 7, A
		{ L"RES", Function::RES, Addressing::Value0, Addressing::ByteReg_B, 8, 0, 0, }, // CB80: RES 0, B
		{ L"RES", Function::RES, Addressing::Value0, Addressing::ByteReg_C, 8, 0, 0, }, // CB81: RES 0, C
		{ L"RES", Function::RES, Addressing::Value0, Addressing::ByteReg_D, 8, 0, 0, }, // CB82: RES 0, D
		{ L"RES", Function::RES, Addressing::Value0, Addressing::ByteReg_E, 8, 0, 0, }, // CB83: RES 0, E
		{ L"RES", Function::RES, Addressing::Value0, Addressing::ByteReg_H, 8, 0, 0, }, // CB84: RES 0, H
		{ L"RES", Function::RES, Addressing::Value0, Addressing::ByteReg_L, 8, 0, 0, }, // CB85: RES 0, L
		{ L"RES", Function::RES, Addressing::Value0, Addressing::WordReg_HLRef, 16, 0, 0, }, // CB86: RES 0, (HL)
		{ L"RES", Function::RES, Addressing::Value0, Addressing::ByteReg_A, 8, 0, 0, }, // CB87: RES 0, A
		{ L"RES", Function::RES, Addressing::Value1, Addressing::ByteReg_B, 8, 0, 0, }, // CB88: RES 1, B
		{ L"RES", Function::RES, Addressing::Value1, Addressing::ByteReg_C, 8, 0, 0, }, // CB89: RES 1, C
		{ L"RES", Function::RES, Addressing::Value1, Addressing::ByteReg_D, 8, 0, 0, }, // CB8A: RES 1, D
		{ L"RES", Function::RES, Addressing::Value1, Addressing::ByteReg_E, 8, 0, 0, }, // CB8B: RES 1, E
		{ L"RES", Function::RES, Addressing::Value1, Addressing::ByteReg_H, 8, 0, 0, }, // CB8C: RES 1, H
		{ L"RES", Function::RES, Addressing::Value1, Addressing::ByteReg_L, 8, 0, 0, }, // CB8D: RES 1, L
		{ L"RES", Function::RES, Addressing::Value1, Addressing::WordReg_HLRef, 16, 0, 0, }, // CB8E: RES 1, (HL)
		{ L"RES", Function::RES, Addressing::Value1, Addressing::ByteReg_A, 8, 0, 0, }, // CB8F: RES 1, A
		{ L"RES", Function::RES, Addressing::Value2, Addressing::ByteReg_B, 8, 0, 0, }, // CB90: RES 2, B
		{ L"RES", Function::RES, Addressing::Value2, Addressing::ByteReg_C, 8, 0, 0, }, // CB91: RES 2, C
		{ L"RES", Function::RES, Addressing::Value2, Addressing::ByteReg_D, 8, 0, 0, }, // CB92: RES 2, D
		{ L"RES", Function::RES, Addressing::Value2, Addressing::ByteReg_E, 8, 0, 0, }, // CB93: RES 2, E
		{ L"RES", Function::RES, Addressing::Value2, Addressing::ByteReg_H, 8, 0, 0, }, // CB94: RES 2, H
		{ L"RES", Function::RES, Addressing::Value2, Addressing::ByteReg_L, 8, 0, 0, }, // CB95: RES 2, L
		{ L"RES", Function::RES, Addressing::Value2, Addressing::WordReg_HLRef, 16, 0, 0, }, // CB96: RES 2, (HL)
		{ L"RES", Function::RES, Addressing::Value2, Addressing::ByteReg_A, 8, 0, 0, }, // CB97: RES 2, A
		{ L"RES", Function::RES, Addressing::Value3, Addressing::ByteReg_B, 8, 0, 0, }, // CB98: RES 3, B
		{ L"RES", Function::RES, Addressing::Value3, Addressing::ByteReg_C, 8, 0, 0, }, // CB99: RES 3, C
		{ L"RES", Function::RES, Addressing::Value3, Addressing::ByteReg_D, 8, 0, 0, }, // CB9A: RES 3, D
		{ L"RES", Function::RES, Addressing::Value3, Addressing::ByteReg_E, 8, 0, 0, }, // CB9B: RES 3, E
		{ L"RES", Function::RES, Addressing::Value3, Addressing::ByteReg_H, 8, 0, 0, }, // CB9C: RES 3, H
		{ L"RES", Function::RES, Addressing::Value3, Addressing::ByteReg_L, 8, 0, 0, }, // CB9D: RES 3, L
		{ L"RES", Function::RES, Addressing::Value3, Addressing::WordReg_HLRef, 16, 0, 0, }, // CB9E: RES 3, (HL)
		{ L"RES", Function::RES, Addressing::Value3, Addressing::ByteReg_A, 8, 0, 0, }, // CB9F: RES 3, A
		{ L"RES", Function::RES, Addressing::Value4, Addressing::ByteReg_B, 8, 0, 0, }, // CBA0: RES 4, B
		{ L"RES", Function::RES, Addressing::Value4, Addressing::ByteReg_C, 8, 0, 0, }, // CBA1: RES 4, C
		{ L"RES", Function::RES, Addressing::Value4, Addressing::ByteReg_D, 8, 0, 0, }, // CBA2: RES 4, D
		{ L"RES", Function::RES, Addressing::Value4, Addressing::ByteReg_E, 8, 0, 0, }, // CBA3: RES 4, E
		{ L"RES", Function::RES, Addressing::Value4, Addressing::ByteReg_H, 8, 0, 0, }, // CBA4: RES 4, H
		{ L"RES", Function::RES, Addressing::Value4, Addressing::ByteReg_L, 8, 0, 0, }, // CBA5: RES 4, L
		{ L"RES", Function::RES, Addressing::Value4, Addressing::WordReg_HLRef, 16, 0, 0, }, // CBA6: RES 4, (HL)
		{ L"RES", Function::RES, Addressing::Value4, Addressing::ByteReg_A, 8, 0, 0, }, // CBA7: RES 4, A
		{ L"RES", Function::RES, Addressing::Value5, Addressing::ByteReg_B, 8, 0, 0, }, // CBA8: RES 5, B
		{ L"RES", Function::RES, Addressing::Value5, Addressing::ByteReg_C, 8, 0, 0, }, // CBA9: RES 5, C
		{ L"RES", Function::RES, Addressing::Value5, Addressing::ByteReg_D, 8, 0, 0, }, // CBAA: RES 5, D
		{ L"RES", Function::RES, Addressing::Value5, Addressing::ByteReg_E, 8, 0, 0, }, // CBAB: RES 5, E
		{ L"RES", Function::RES, Addressing::Value5, Addressing::ByteReg_H, 8, 0, 0, }, // CBAC: RES 5, H
		{ L"RES", Function::RES, Addressing::Value5, Addressing::ByteReg_L, 8, 0, 0, }, // CBAD: RES 5, L
		{ L"RES", Function::RES, Addressing::Value5, Addressing::WordReg_HLRef, 16, 0, 0, }, // CBAE: RES 5, (HL)
		{ L"RES", Function::RES, Addressing::Value5, Addressing::ByteReg_A, 8, 0, 0, }, // CBAF: RES 5, A
		{ L"RES", Function::RES, Addressing::Value6, Addressing::ByteReg_B, 8, 0, 0, }, // CBB0: RES 6, B
		{ L"RES", Function::RES, Addressing::Value6, Addressing::ByteReg_C, 8, 0, 0, }, // CBB1: RES 6, C
		{ L"RES", Function::RES, Addressing::Value6, Addressing::ByteReg_D, 8, 0, 0, }, // CBB2: RES 6, D
		{ L"RES", Function::RES, Addressing::Value6, Addressing::ByteReg_E, 8, 0, 0, }, // CBB3: RES 6, E
		{ L"RES", Function::RES, Addressing::Value6, Addressing::ByteReg_H, 8, 0, 0, }, // CBB4: RES 6, H
		{ L"RES", Function::RES, Addressing::Value6, Addressing::ByteReg_L, 8, 0, 0, }, // CBB5: RES 6, L
		{ L"RES", Function::RES, Addressing::Value6, Addressing::WordReg_HLRef, 16, 0, 0, }, // CBB6: RES 6, (HL)
		{ L"RES", Function::RES, Addressing::Value6, Addressing::ByteReg_A, 8, 0, 0, }, // CBB7: RES 6, A
		{ L"RES", Function::RES, Addressing::Value7, Addressing::ByteReg_B, 8, 0, 0, }, // CBB8: RES 7, B
		{ L"RES", Function::RES, Addressing::Value7, Addressing::ByteReg_C, 8, 0, 0, }, // CBB9: RES 7, C
		{ L"RES", Function::RES, Addressing::Value7, Addressing::ByteReg_D, 8, 0, 0, }, // CBBA: RES 7, D
		{ L"RES", Function::RES, Addressing::Value7, Addressing::ByteReg_E, 8, 0, 0, }, // CBBB: RES 7, E
		{ L"RES", Function::RES, Addressing::Value7, Addressing::ByteReg_H, 8, 0, 0, }, // CBBC: RES 7, H
		{ L"RES", Function::RES, Addressing::Value7, Addressing::ByteReg_L, 8, 0, 0, }, // CBBD: RES 7, L
		{ L"RES", Function::RES, Addressing::Value7, Addressing::WordReg_HLRef, 16, 0, 0, }, // CBBE: RES 7, (HL)
		{ L"RES", Function::RES, Addressing::Value7, Addressing::ByteReg_A, 8, 0, 0, }, // CBBF: RES 7, A
		{ L"SET", Function::SET, Addressing::Value0, Addressing::ByteReg_B, 8, 0, 0, }, // CBC0: SET 0, B
		{ L"SET", Function::SET, Addressing::Value0, Addressing::ByteReg_C, 8, 0, 0, }, // CBC1: SET 0, C
		{ L"SET", Function::SET, Addressing::Value0, Addressing::ByteReg_D, 8, 0, 0, }, // CBC2: SET 0, D
		{ L"SET", Function::SET, Addressing::Value0, Addressing::ByteReg_E, 8, 0, 0, }, // CBC3: SET 0, E
		{ L"SET", Function::SET, Addressing::Value0, Addressing::ByteReg_H, 8, 0, 0, }, // CBC4: SET 0, H
		{ L"SET", Function::SET, Addressing::Value0, Addressing::ByteReg_L, 8, 0, 0, }, // CBC5: SET 0, L
		{ L"SET", Function::SET, Addressing::Value0, Addressing::WordReg_HLRef, 16, 0, 0, }, // CBC6: SET 0, (HL)
		{ L"SET", Function::SET, Addressing::Value0, Addressing::ByteReg_A, 8, 0, 0, }, // CBC7: SET 0, A
		{ L"SET", Function::SET, Addressing::Value1, Addressing::ByteReg_B, 8, 0, 0, }, // CBC8: SET 1, B
		{ L"SET", Function::SET, Addressing::Value1, Addressing::ByteReg_C, 8, 0, 0, }, // CBC9: SET 1, C
		{ L"SET", Function::SET, Addressing::Value1, Addressing::ByteReg_D, 8, 0, 0, }, // CBCA: SET 1, D
		{ L"SET", Function::SET, Addressing::Value1, Addressing::ByteReg_E, 8, 0, 0, }, // CBCB: SET 1, E
		{ L"SET", Function::SET, Addressing::Value1, Addressing::ByteReg_H, 8, 0, 0, }, // CBCC: SET 1, H
		{ L"SET", Function::SET, Addressing::Value1, Addressing::ByteReg_L, 8, 0, 0, }, // CBCD: SET 1, L
		{ L"SET", Function::SET, Addressing::Value1, Addressing::WordReg_HLRef, 16, 0, 0, }, // CBCE: SET 1, (HL)
		{ L"SET", Function::SET, Addressing::Value1, Addressing::ByteReg_A, 8, 0, 0, }, // CBCF: SET 1, A
		{ L"SET", Function::SET, Addressing::Value2, Addressing::ByteReg_B, 8, 0, 0, }, // CBD0: SET 2, B
		{ L"SET", Function::SET, Addressing::Value2, Addressing::ByteReg_C, 8, 0, 0, }, // CBD1: SET 2, C
		{ L"SET", Function::SET, Addressing::Value2, Addressing::ByteReg_D, 8, 0, 0, }, // CBD2: SET 2, D
		{ L"SET", Function::SET, Addressing::Value2, Addressing::ByteReg_E, 8, 0, 0, }, // CBD3: SET 2, E
		{ L"SET", Function::SET, Addressing::Value2, Addressing::ByteReg_H, 8, 0, 0, }, // CBD4: SET 2, H
		{ L"SET", Function::SET, Addressing::Value2, Addressing::ByteReg_L, 8, 0, 0, }, // CBD5: SET 2, L
		{ L"SET", Function::SET, Addressing::Value2, Addressing::WordReg_HLRef, 16, 0, 0, }, // CBD6: SET 2, (HL)
		{ L"SET", Function::SET, Addressing::Value2, Addressing::ByteReg_A, 8, 0, 0, }, // CBD7: SET 2, A
		{ L"SET", Function::SET, Addressing::Value3, Addressing::ByteReg_B, 8, 0, 0, }, // CBD8: SET 3, B
		{ L"SET", Function::SET, Addressing::Value3, Addressing::ByteReg_C, 8, 0, 0, }, // CBD9: SET 3, C
		{ L"SET", Function::SET, Addressing::Value3, Addressing::ByteReg_D, 8, 0, 0, }, // CBDA: SET 3, D
		{ L"SET", Function::SET, Addressing::Value3, Addressing::ByteReg_E, 8, 0, 0, }, // CBDB: SET 3, E
		{ L"SET", Function::SET, Addressing::Value3, Addressing::ByteReg_H, 8, 0, 0, }, // CBDC: SET 3, H
		{ L"SET", Function::SET, Addressing::Value3, Addressing::ByteReg_L, 8, 0, 0, }, // CBDD: SET 3, L
		{ L"SET", Function::SET, Addressing::Value3, Addressing::WordReg_HLRef, 16, 0, 0, }, // CBDE: SET 3, (HL)
		{ L"SET", Function::SET, Addressing::Value3, Addressing::ByteReg_A, 8, 0, 0, }, // CBDF: SET 3, A
		{ L"SET", Function::SET, Addressing::Value4, Addressing::ByteReg_B, 8, 0, 0, }, // CBE0: SET 4, B
		{ L"SET", Function::SET, Addressing::Value4, Addressing::ByteReg_C, 8, 0, 0, }, // CBE1: SET 4, C
		{ L"SET", Function::SET, Addressing::Value4, Addressing::ByteReg_D, 8, 0, 0, }, // CBE2: SET 4, D
		{ L"SET", Function::SET, Addressing::Value4, Addressing::ByteReg_E, 8, 0, 0, }, // CBE3: SET 4, E
		{ L"SET", Function::SET, Addressing::Value4, Addressing::ByteReg_H, 8, 0, 0, }, // CBE4: SET 4, H
		{ L"SET", Function::SET, Addressing::Value4, Addressing::ByteReg_L, 8, 0, 0, }, // CBE5: SET 4, L
		{ L"SET", Function::SET, Addressing::Value4, Addressing::WordReg_HLRef, 16, 0, 0, }, // CBE6: SET 4, (HL)
		{ L"SET", Function::SET, Addressing::Value4, Addressing::ByteReg_A, 8, 0, 0, }, // CBE7: SET 4, A
		{ L"SET", Function::SET, Addressing::Value5, Addressing::ByteReg_B, 8, 0, 0, }, // CBE8: SET 5, B
		{ L"SET", Function::SET, Addressing::Value5, Addressing::ByteReg_C, 8, 0, 0, }, // CBE9: SET 5, C
		{ L"SET", Function::SET, Addressing::Value5, Addressing::ByteReg_D, 8, 0, 0, }, // CBEA: SET 5, D
		{ L"SET", Function::SET, Addressing::Value5, Addressing::ByteReg_E, 8, 0, 0, }, // CBEB: SET 5, E
		{ L"SET", Function::SET, Addressing::Value5, Addressing::ByteReg_H, 8, 0, 0, }, // CBEC: SET 5, H
		{ L"SET", Function::SET, Addressing::Value5, Addressing::ByteReg_L, 8, 0, 0, }, // CBED: SET 5, L
		{ L"SET", Function::SET, Addressing::Value5, Addressing::WordReg_HLRef, 16, 0, 0, }, // CBEE: SET 5, (HL)
		{ L"SET", Function::SET, Addressing::Value5, Addressing::ByteReg_A, 8, 0, 0, }, // CBEF: SET 5, A
		{ L"SET", Function::SET, Addressing::Value6, Addressing::ByteReg_B, 8, 0, 0, }, // CBF0: SET 6, B
		{ L"SET", Function::SET, Addressing::Value6, Addressing::ByteReg_C, 8, 0, 0, }, // CBF1: SET 6, C
		{ L"SET", Function::SET, Addressing::Value6, Addressing::ByteReg_D, 8, 0, 0, }, // CBF2: SET 6, D
		{ L"SET", Function::SET, Addressing::Value6, Addressing::ByteReg_E, 8, 0, 0, }, // CBF3: SET 6, E
		{ L"SET", Function::SET, Addressing::Value6, Addressing::ByteReg_H, 8, 0, 0, }, // CBF4: SET 6, H
		{ L"SET", Function::SET, Addressing::Value6, Addressing::ByteReg_L, 8, 0, 0, }, // CBF5: SET 6, L
		{ L"SET", Function::SET, Addressing::Value6, Addressing::WordReg_HLRef, 16, 0, 0, }, // CBF6: SET 6, (HL)
		{ L"SET", Function::SET, Addressing::Value6, Addressing::ByteReg_A, 8, 0, 0, }, // CBF7: SET 6, A
		{ L"SET", Function::SET, Addressing::Value7, Addressing::ByteReg_B, 8, 0, 0, }, // CBF8: SET 7, B
		{ L"SET", Function::SET, Addressing::Value7, Addressing::ByteReg_C, 8, 0, 0, }, // CBF9: SET 7, C
		{ L"SET", Function::SET, Addressing::Value7, Addressing::ByteReg_D, 8, 0, 0, }, // CBFA: SET 7, D
		{ L"SET", Function::SET, Addressing::Value7, Addressing::ByteReg_E, 8, 0, 0, }, // CBFB: SET 7, E
		{ L"SET", Function::SET, Addressing::Value7, Addressing::ByteReg_H, 8, 0, 0, }, // CBFC: SET 7, H
		{ L"SET", Function::SET, Addressing::Value7, Addressing::ByteReg_L, 8, 0, 0, }, // CBFD: SET 7, L
		{ L"SET", Function::SET, Addressing::Value7, Addressing::WordReg_HLRef, 16, 0, 0, }, // CBFE: SET 7, (HL)
		{ L"SET", Function::SET, Addressing::Value7, Addressing::ByteReg_A, 8, 0, 0, }, // CBFF: SET 7, A
    };
}

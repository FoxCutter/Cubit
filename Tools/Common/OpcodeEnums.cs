namespace OpcodeData
{
    public enum CommandID
    {
        None,
        ACI, 
        ADC, 
        ADD, 
        ADI, 
        ANA, 
        AND, 
        ANI, 
        ARHL, 
        BIT, 
        CALL, 
        CC, 
        CCF, 
        CM, 
        CMA, 
        CMC, 
        CMP, 
        CNC, 
        CNZ, 
        CP, 
        CPD, 
        CPDR, 
        CPE, 
        CPI, 
        CPIR, 
        CPL, 
        CPO, 
        CZ, 
        DAA, 
        DAD, 
        DCR, 
        DCX, 
        DEC, 
        DI, 
        DJNZ, 
        DSUB, 
        EI, 
        EX, 
        EXX, 
        HALT, 
        HLT, 
        IM, 
        IN, 
        INC, 
        IND, 
        INDR, 
        INI, 
        INIR, 
        INR, 
        INX, 
        JC, 
        JK, 
        JM, 
        JMP, 
        JNC, 
        JNK, 
        JNZ, 
        JP, 
        JPE, 
        JPO, 
        JR, 
        JZ, 
        LD, 
        LDA, 
        LDAX, 
        LDD, 
        LDDR, 
        LDH, 
        LDHI, 
        LDHL, 
        LDI, 
        LDIR, 
        LDSI, 
        LDX, 
        LHLD, 
        LHLDE, 
        LHLX, 
        LXI, 
        MOV, 
        MVI, 
        NEG, 
        NOP, 
        OR, 
        ORA, 
        ORI, 
        OTDR, 
        OTIR, 
        OUT, 
        OUTD, 
        OUTI, 
        PCHL, 
        POP, 
        PUSH, 
        RAL, 
        RAR, 
        RC, 
        RDLE, 
        RES, 
        RET, 
        RETI, 
        RETN, 
        RIM, 
        RL, 
        RLA, 
        RLC, 
        RLCA, 
        RLD, 
        RM, 
        RNC, 
        RNZ, 
        RP, 
        RPE, 
        RPO, 
        RR, 
        RRA, 
        RRC, 
        RRCA, 
        RRD, 
        RST, 
        RSTV, 
        RZ, 
        SBB, 
        SBC, 
        SBI, 
        SCF, 
        SET, 
        SHLD, 
        SHLDE, 
        SHLX, 
        SIM, 
        SL1, 
        SLA, 
        SLL, 
        SPHL, 
        SRA, 
        SRL, 
        STA, 
        STAX, 
        STC, 
        STOP, 
        SUB, 
        SUI, 
        SWAP, 
        XCHG, 
        XOR, 
        XRA, 
        XRI, 
        XTHL, 
    }

    public enum FunctionID
    {
        None,
        ADD, 
        ADD_CY, 
        AND, 
        BCD_ADJUST, 
        BIT, 
        CALL, 
        CMP, 
        CMP_D, 
        CMP_DR, 
        CMP_I, 
        CMP_IR, 
        CY_INVERT, 
        CY_SET, 
        DEC, 
        DI, 
        DJNZ, 
        EI, 
        EX, 
        EXX, 
        HALT, 
        IM, 
        IN, 
        IN_D, 
        IN_DR, 
        IN_I, 
        IN_IR, 
        INC, 
        JMP, 
        JMPR, 
        LOAD, 
        LOAD_D, 
        LOAD_DEC, 
        LOAD_DR, 
        LOAD_HIGH, 
        LOAD_I, 
        LOAD_INC, 
        LOAD_IR, 
        LOAD_SP, 
        NEG, 
        NOP, 
        NOT, 
        OR, 
        OUT, 
        OUT_D, 
        OUT_DR, 
        OUT_I, 
        OUT_IR, 
        POP, 
        PREFIX, 
        PUSH, 
        RES, 
        RET, 
        RETI, 
        RETN, 
        RIM, 
        RL, 
        RL_CY, 
        ROLL_L, 
        ROLL_R, 
        RR, 
        RR_CY, 
        RST, 
        SET, 
        SIM, 
        SL_L, 
        SL_SIGNED, 
        SR_L, 
        SR_SIGNED, 
        STOP, 
        SUB, 
        SUB_CY, 
        SWAP, 
        XOR, 
    }
}

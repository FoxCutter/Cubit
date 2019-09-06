﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=4.6.1055.0.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
public partial class z80Opcodes {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("platform", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public z80OpcodesPlatform[] platform;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class z80OpcodesPlatform {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("opcode", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public opcodeType[] opcode;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class opcodeType {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string mnemonic;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("arg", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
    public argType[] args;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string official;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string function;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.ComponentModel.DefaultValueAttribute(typeof(short), "0")]
    public short cycles;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string flags;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string description;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(true)]
    public bool prefered;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(false)]
    public bool index;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="hexBinary")]
    public byte[] prefix;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="hexBinary")]
    public byte[] value;
    
    public opcodeType() {
        this.cycles = ((short)(0));
        this.prefered = true;
        this.index = false;
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class argType {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public EncodingEnum encoding;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(false)]
    public bool hidden;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value;
    
    public argType() {
        this.hidden = false;
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
public enum EncodingEnum {
    
    /// <remarks/>
    None,
    
    /// <remarks/>
    Reg2,
    
    /// <remarks/>
    Reg1,
    
    /// <remarks/>
    Flag,
    
    /// <remarks/>
    WordReg,
    
    /// <remarks/>
    HalfFlag,
    
    /// <remarks/>
    ByteImmidate,
    
    /// <remarks/>
    WordImmidate,
    
    /// <remarks/>
    IndexOffset,
    
    /// <remarks/>
    Direct,
}
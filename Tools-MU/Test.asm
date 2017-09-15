	ADD 10
	
	ld IX, $4000
	ld A, (IX - Alpha - 12)


.z80
                  
.section size $4000 
.org $0000 

	
.end


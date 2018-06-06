;.include "MasterV5.3-zmac.z80"

.IF 0
	jp nc, test1
.ELSE 
	IF 1
		jp nc, $ffff

	ELSE
		nop
	ENDIF
.ENDIF

	jp nc, 0

;temp = 'BCK'
;	db	Temp
;
;.z80
;                  
;.section "" size $4000 pos $10000 fill $42
;.org $0000 
;
;
;	LD 	BC, Temp
;	
;
;.end

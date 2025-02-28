.686P  
.MODEL FLAT, C  

.DATA  
MB_OK    EQU 0  
STR1     DB «Ìמÿ ןונגאÿ ןנמדנאללא»,0  
STR2     DB «Ïנטגוע גסול!»,0  
HW       DD ?  
EXTERN MessageBoxA@16:NEAR  

.CODE  
START:  
PUSH     MB_OK  
PUSH     OFFSET STR1  
PUSH     OFFSET STR2  
PUSH     HW  
CALL     MessageBoxA@16  
RET  
END START
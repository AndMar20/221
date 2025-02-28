.386
.model flat, c
.stack 4096
.data

public SumNumber

.code

SumNumber PROC
	enter 0,0

	mov eax, [ebp + 8]	
	mov ebx, [ebp + 12]

	add eax, ebx

	leave	
	ret
SumNumber ENDP

END
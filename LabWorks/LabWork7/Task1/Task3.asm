.686
.model flat, c, stdcall
.stack 4096

.data
	str1 db "help", 0
	str2 db "help", 0
	msgEqual db "Строки равны", 0
	msgNotEqual db "Строки разные", 0
	HW dd ?
	EXTERN MessageBoxA@16: NEAR

public Compare
.code
Compare PROC
	lea eax, str1
	lea ebx, str2

compare_loop:
	mov al, [eax]
	mov bl, [ebx]
	cmp al, bl
	jne strings_not_equal
	cmp al, 0
	je strings_are_equal
	inc eax
	inc ebx
	jmp compare_loop

strings_are_equal:
	lea eax, msgEqual
jmp end_cmp
strings_not_equal:
	lea eax, msgNotEqual
end_cmp:
	push 0
	push 0
	push eax
	push HW
	call MessageBoxA@16
	ret

Compare ENDP
END
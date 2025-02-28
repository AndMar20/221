.386
.model flat, c
.stack 4096
.data

.code
Double PROC
	push ebp
	mov ebp, esp
	mov ecx, [ebp + 8]
	mov eax, 1

pow_loop:
	test ecx, ecx
	jz done
	shl eax, 1
	loop pow_loop

done:
	pop ebp
	ret

Double ENDP
END
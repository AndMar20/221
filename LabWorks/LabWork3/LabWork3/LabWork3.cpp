#include <iostream>
using namespace std;

int task1 (int n) {
	if (n < 0) {
		std::cout << "net takogo" << endl;
	}
	else {
		int result = 1;

		_asm {
			mov eax, n
			mov ebx, 1
			start1:
			cmp eax, 0
			je end1
			mul ebx
			mov ebx, eax
			dec eax
			mul ebx
			mov ebx, eax
			je start1
		end1 :
			mov result, ebx
		}
		cout << "Факториал числа " << n << " равен: " << result << endl;
	}
}

int task2(int n) {
	if (n <= 0) {
		cout << "no" << endl;
	}
	int count = 0;
	int sqrt_n = sqrt(n);

	_asm {
		mov eax, n
		mov ebx, 1
		mov ecx, 0
		mov esi, sqrt_n
	 start1:
		cmp ebx, esi
		jg end1
		mov edx, 0
		mov eax, n
		div ebx
		cmp edx, 0
		jne increment_i
			mov eax, n
			div ebx
			cmp ebx,eax
			je increment_count
			add ecx, 2
			jmp  increment_i
	 increment_count:
		inc ecx
	 increment_i:
		inc ebx
		jmp start1
	 end1:
		mov count, ecx
	}
	cout << "Количество делителей числа " << n << ": " << count << endl;
}

void print_number(int num) {
	cout << num << " ";
}

int task3(int n) {
	_asm {
		mov eax, n
	print_loop:
		cmp eax, 0
		jl end1
		push eax
		push eax
		call print_number
		add esp, 4
		pop eax
		sub eax, 5
		jmp print_loop
	end1:
	}
}

int task4() {
	int table[10][10];

	_asm {
		mov ecx, 0
		outer_loop:
		cmp ecx, 10
			jge end_outer
			mov edx, 0
			inner_loop :
			cmp edx, 10
			jge end_inner
			mov eax, ecx
			inc eax
			mov ebx, edx
			inc ebx imul eax, ebx
			mov tamle[ecx * 40 + edx * 4], eax
			inc edx
			jmp inner_loop
			end_inner :
		inc ecx
			jmp outer_loop
			end_outer :
	}

	for (int i = 1; i <= 10; i++) {
		cout << i << "\t";
	}

	for (int i = 0; i < 10; i++) {
		cout << (i + 1) << "| ";
		for (int j = 0; j < 10; j++) {
			cout << table[i][j] << "\t";
		}
		cout << endl;
	}
}

int main() {
	setlocale(LC_ALL, "ru");
	int n = 10;
	
	task1(n);
	task2(n);
	task3(n);
	task4();
}



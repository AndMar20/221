#include <iostream>

using namespace std;

static const char format[] = "%d";

int inputDiv() {
	cout << "Введите делитель: ";
	return 0;
}
int main()
{
	//Task1
	setlocale(LC_ALL, "ru");
	int a, b, result;

	std::cout << "Введите делимое: ";
	cin >> a;

	_asm {
	input_loop:
		call inputDiv
		lea ebx, b
		push ebx
		push offset format
		call scanf_s
		add esp, 8
		cmp b, 0
		je input_loop
	}

	_asm {
		mov eax,a
		cdq
		idiv b
		mov result, eax
	}

	std::cout << "Результат деления: " << result;

	//Task2
	int random = 5;

	_asm {
		retry:
	}

	cout << "\nУгадай число:\n";
	cin >> result;

	_asm {
		mov eax, random
		mov ebx, result
		cmp ebx, eax
		jl is_lesser
		jg is_greater
		je is_equal
		is_lesser:
	}

	cout << "Маленькое число";

	_asm {
		jmp retry
		is_greater:
	}

	cout << "Большое число";

	_asm {
		jmp retry
		is_equal:
	}
	cout << "Ты молодец!";

	//double deposit, rate;
	//int years = 0;
	//double million = 1000000.0;
	//static const char format_double[] = "%lf";
	//cout << "Введите сумму вклада: ";
	//cin >> deposit;
	//cout << "Введите процент годовых: ";
	//cin >> rate;

	//_asm {
	//start_calc:
	//	fld deposit
	//	fmul rate
	//	fdiv dword ptr [100.0]
	//	fadd deposit
	//	fstp deposit
	//	inc years

	//	fld deposit
	//	fcomp million
	//	fstsw ax
	//	sahf
	//	jb start_calc
	//}

	//cout << "Вы станете миллионером через" << years << "лет";
}

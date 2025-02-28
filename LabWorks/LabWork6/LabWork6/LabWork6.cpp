#include <iostream>
#include <cstring>
using namespace std;

int main() {
	char str1[] = "Hello";
	char str2[10];
	int i = sizeof(str1);
	_asm {
		lea esi, str1
		lea edi, str2
		mov ecx, i
		rep movsb
	}

	cout << str1;
	cout << str2;
}

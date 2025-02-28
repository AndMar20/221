#include <iostream>
using namespace std;
int main() {
	setlocale(LC_ALL, "ru");
	int scrArr[5] = { 1,2,3,4,5 };
	int destArr[5] = { 0 };
	int x = sizeof(scrArr);
	_asm {
		lea esi, scrArr
		lea edi, destArr
		mov ecx, x
		rep movsb
	}

	cout << "Скопированный массив: ";
	for (int i : destArr) cout << i << " ";
}
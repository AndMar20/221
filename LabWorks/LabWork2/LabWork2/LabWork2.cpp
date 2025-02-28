#include <iostream>
using namespace std;

int main()
{
    setlocale(LC_ALL, "Ru");
    int a = 5;
    int b = 1;
    int min;

    _asm {
        mov eax, a
        mov ebx, b
        cmp eax, ebx
        jle Done
        mov min, ebx
        jmp end1
    Done :
        mov min, eax
    end1 : 
    }
    cout << "Минимальное: " << min << endl;

    a = 1;
    b = 5;
    int c = 7;
    int max;

    _asm {
        mov eax, a
        cmp eax, b
        jge check_c
        mov eax, b
    check_c:
        cmp eax, c
        jge done_max
        mov eax, c
    done_max:
        mov max, eax
    }
    cout << "Максимальное: " << max << endl;

    a = 1;
    int x = 2;
    int y;

    __asm {
        mov eax, x
        cmp eax, -10
        jl square
        cmp eax, 10
        jl absval
        jmp subtract
    square :
        imul eax, eax
        imul eax, a
        jmp done_y
    absval :
        cdq
        xor eax, edx
        sub eax, edx
        imul eax, a
        jmp done_y
    subtract :
        mov eax, a
        sub eax, x
    done_y :
        mov y, eax
    }
    cout << "y(" << x << ") = " << y << endl;

    int month;
    int days;
    cout << "Введите номер месяца : ";
    cin >> month;
    __asm {
        mov eax, month
        cmp eax, 2
        je feb
        cmp eax, 4
        je thirty
        cmp eax, 6
        je thirty
        cmp eax, 9
        je thirty
        cmp eax, 11
        je thirty
        jmp thirty_one
    feb :
        mov eax, 28
        jmp done_days
    thirty :
        mov eax, 30
        jmp done_days
    thirty_one :
        mov eax, 31
    done_days :
        mov days, eax
    }
        
    cout << "В этом месяце " << days << " дней." << endl;

    int cost, paid, change;
    cout << "Введите сумму покупки: ";
    cin >> cost;
    cout << "Введите внесенную сумму: ";
    cin >> paid;
    
    __asm {
        mov eax, paid
        sub eax, cost
        mov change, eax
    }
    
    if (change == 0) cout << "Спасибо!" << endl;
    else if (change > 0) cout << "Возьмите сдачу: " << change << endl;
    else cout << "Недостаточно денег! Нужно ещё " << -change << endl;
}
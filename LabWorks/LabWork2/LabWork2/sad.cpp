//#include <iostream>
//using namespace std;
//
//int main() {
//    int choice;
//    do {
//        cout << "\n�������� �������:\n"
//            << "1 - ������� �� ���� �����\n"
//            << "2 - �������� �� ���� �����\n"
//            << "3 - ���������� ������� y(x)\n"
//            << "4 - ���������� ���� � ������\n"
//            << "5 - ������ �����\n"
//            << "0 - �����\n"
//            << "��� �����: ";
//        cin >> choice;
//
//        if (choice == 1) {
//            int a, b, min;
//            cout << "������� ��� �����: ";
//            cin >> a >> b;
//
//            __asm {
//                mov eax, a
//                cmp eax, b
//                jle done_min
//                mov eax, b
//                done_min :
//                mov min, eax
//            }
//
//            cout << "�������: " << min << endl;
//        }
//        else if (choice == 2) {
//            int a, b, c, max;
//            cout << "������� ��� �����: ";
//            cin >> a >> b >> c;
//
//            __asm {
//                mov eax, a
//                cmp eax, b
//                jge check_c
//                mov eax, b
//
//                check_c :
//                cmp eax, c
//                    jge done_max
//                    mov eax, c
//
//                    done_max :
//                mov max, eax
//            }
//
//            cout << "��������: " << max << endl;
//        }
//        else if (choice == 3) {
//            int a, x, y;
//            cout << "������� a � x: ";
//            cin >> a >> x;
//
//            __asm {
//                mov eax, x
//                cmp eax, -10
//                jl square
//                cmp eax, 10
//                jl absval
//                jmp subtract
//
//                square :
//                imul eax, eax
//                    imul eax, a
//                    jmp done_y
//
//                    absval :
//                cdq
//                    xor eax, edx
//                    sub eax, edx
//                    imul eax, a
//                    jmp done_y
//
//                    subtract :
//                mov eax, a
//                    sub eax, x
//
//                    done_y :
//                mov y, eax
//            }
//
//            cout << "y(x) = " << y << endl;
//        }
//        else if (choice == 4) {
//            int month, days;
//            cout << "������� ����� ������ (1-12): ";
//            cin >> month;
//
//            __asm {
//                mov eax, month
//                cmp eax, 2
//                je feb
//                cmp eax, 4
//                je thirty
//                cmp eax, 6
//                je thirty
//                cmp eax, 9
//                je thirty
//                cmp eax, 11
//                je thirty
//                jmp thirty_one
//
//                feb :
//                mov eax, 28
//                    jmp done_days
//
//                    thirty :
//                mov eax, 30
//                    jmp done_days
//
//                    thirty_one :
//                mov eax, 31
//
//                    done_days :
//                    mov days, eax
//            }
//
//            cout << "� ���� ������ " << days << " ����." << endl;
//        }
//        else if (choice == 5) {
//            int cost, paid, change;
//            cout << "������� ����� �������: ";
//            cin >> cost;
//            cout << "������� ��������� �����: ";
//            cin >> paid;
//
//            __asm {
//                mov eax, paid
//                cmp eax, cost
//                je no_change
//                jg give_change
//                jmp not_enough
//
//                give_change :
//                sub eax, cost
//                    mov change, eax
//                    jmp done_change
//
//                    not_enough :
//                sub cost, paid
//                    mov change, cost
//                    neg change
//                    jmp done_change
//
//                    no_change :
//                mov change, 0
//
//                    done_change :
//            }
//
//            if (change == 0) cout << "�������!" << endl;
//            else if (change > 0) cout << "�������� �����: " << change << endl;
//            else cout << "������������ �����! ����� ��� " << -change << endl;
//        }
//    } while (choice != 0);
//
//    return 0;
//}

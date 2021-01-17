/*
Datos:
    Un entero, la cantidad de estudiantes.No hay mas de
    1000 estudiantes

    Por cada estudiante , un numero real, la cantidad
    de dinero que gasto , siempre menor o igual que
    10000 dollars.
Incognita:
    La cantidad minima de dinero que debe cambiar de mano
    para equiparar los costos del viaje entre todos.
*/
#include<bits/stdc++.h>
using namespace std;

int main()
{
    ios_base::sync_with_stdio (0);
    cin.tie (0);

    cout.precision (2); //La salida en decimal se hara hasta las centesimas

    int students;
    while (cin >> students)
    {
        if (!students)
            break;

        double *gastos = new double[students];
        double suma = 0.0;
        for (int i = 0; i < students; ++i)
        {
            cin >> gastos[i];
            gastos[i] *= 100.00;
            suma += gastos[i];
        }
        double media = suma / static_cast<double> (students);
        
        double over_media = 0.00, below_media = 0.00;
        for (int i = 0; i < students; ++i)
        {
            if (gastos[i] > media)
            {
                double temp = gastos[i] - media;
                temp = floor (temp);
                over_media += temp;
            }
            else
            {
                double temp = media - gastos[i];
                temp = floor (temp);
                below_media += temp;
            }
        }
        double cambio_minimo = max (below_media, over_media);
        cout << '$' << fixed << cambio_minimo / 100.00 << "\n";

        delete [] gastos;
    }

    return 0;
}

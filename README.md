-------------------------------------------------------------Instrucciones-----------------------------------------------------------------

1. Correr SCRIPTS para creación de la DB en MICROSOFT SQL SERVER ubicados en carpeta /DB

2. Modificar en proyecto APIPuntoVenta el archivo "appsettings.Development.json" modificando la key "DefaultConnection" con el connectionString de la base local creada en su computadora.

3. Levantar proyecto APIPuntoVenta, por defecto iniciara en la documentacion de swagger

4. Hay dos endpoints en el controller de Cobro
	- CobrarYCalcularCambio: dado el importe a pagar y el importe pagado, valida los importes, si no hay error calcula el cambio y graba la transacción
	- ObtenerTransacciones: lista las transacciones hechas ordenadas desde la más reciente a la más antigua

5. En el proyecto APIPuntoVentaTest hay dos metodos para testear el calculo de cambio a devolver


------OPCIONAL------

.- En APIPuntoVenta archivo startup se puede modificar la implementacion del repository para que funcione con EFCore




use dbVenta
--   select * from tbl_producto
--   create trigger tr_venta
--   on dbo.tbl_venta for insert
--   as
--	 update tbl_producto set cantidad = (cantidad - inserted.cantidad)
GO
CREATE TRIGGER tr_venta
ON dbo.tbl_venta
FOR INSERT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;

    UPDATE tbl_producto 
    SET cantidad = p.cantidad - i.cantidad
    FROM tbl_producto p
    INNER JOIN inserted i ON p.productoID = i.producto;

    COMMIT TRANSACTION;
END;

					--ventaDB = new tbl_venta();
     --               ventaDB.codigoventa = item.codigoventa;
     --               ventaDB.estado = item.estado;
     --               ventaDB.empleado = item.empleado;
     --               ventaDB.cliente = item.cliente;
     --               ventaDB.producto = item.producto;
     --               ventaDB.fecha = item.fecha;
     --               ventaDB.formapago = item.formapago;
     --               ventaDB.descuento = item.descuento;
     --               ventaDB.preciounidad = item.preciounidad;
     --               ventaDB.cantidad = item.cantidad;
     --               ventaDB.impuesto = item.impuesto;
     --               ventaDB.total = item.total;
GO

 CREATE TRIGGER tr_venta_precio
ON dbo.tbl_venta
FOR INSERT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;

    UPDATE tbl_venta 
    SET 
		preciounidad = ((p.precio * .25) +  p.precio),
		impuesto = p.precio *.15,
		total = (p.precio + p.precio * .25 + ( p.precio * .15))
    FROM tbl_venta v
    INNER JOIN inserted i ON v.producto = i.producto
	INNER JOIN tbl_producto p ON p.productoID = i.producto

    COMMIT TRANSACTION;
END;

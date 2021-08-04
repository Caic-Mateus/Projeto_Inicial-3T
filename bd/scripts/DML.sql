------------DML-------------
USE TechnoGear

INSERT INTO TipoEquipamento (NomeEquipamento)
VALUES		('Mobiliário'),
			('Informática'),
			('Eletroeletrônico')
;

INSERT INTO Usuario (Nome, Email, Senha)
VALUES		('Caic Mateus', 'caic@email.com', 'caic123'),
			('Eduardo Ferreira', 'eduardo@email.com', 'eduardo123'),
			('Alan da Costa', 'alan@email.com', 'alan123'),
			('Giovanni Iannace', 'giovanni@email.com', 'giovanni123')
;

INSERT INTO Sala (Andar, Nome, Metragem)
VALUES		(1, 'Biblioteca', 45),
			(2, 'Sala 2', 50)
;

INSERT INTO Equipamento (idTipoEquipamento, idUsuario, idSala, Marca, NumeroSerie, NumeroPatrimonio, Situacao, Descricao)
VALUES		(1, 2, 1, 'Multimóveis', 12345, 54321, 1, 'Cadeira de madeira')
;

INSERT INTO Relacao (idEquipamento, idSala, DataEntrada, DataSaida)
VALUES		(1, 1, '02/08/2021', '04/08/2021')
-- Чтоб нужный запрос работал - нужна примерно такая схема
CREATE TABLE product (
	name varchar,
	id int NOT NULL PRIMARY KEY, 
	active bit NOT NULL -- активность записи
	-- ... какие-нибудь дополнительные поля
);

CREATE TABLE category (
	name varchar,
	id int NOT NULL PRIMARY KEY, 
	active bit NOT NULL -- активность записи
	-- ... какие-нибудь дополнительные поля
);
-- Т.к. связь многие ко многим - нужна дополнительная связующая таблица
CREATE TABLE product_category_rel (
	id int NOT NULL PRIMARY KEY, 
	active bit NOT NULL, -- активность записи
	product_id int  NOT NULL,
	category_id int  NOT NULL,
	FOREIGN KEY (product_id) REFERENCES product(id),
	FOREIGN KEY (category_id) REFERENCES category(id)
);


SELECT p.name as product_name,
		c.name as category_name
FROM product p
-- LEFT JOIN - для вывода даже тех продуктов, у которых нет категории
LEFT JOIN product_category_rel pcr on pcr.product_id = p.id
LEFT JOIN category c on c.id = pcr.category_id
-- Для интереса можно ещё брать только активные записи
WHERE COALESCE(p.active, 1)
	AND COALESCE(pcr.active, 1)
	AND COALESCE(c.active, 1)
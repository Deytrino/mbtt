SELECT p.name as product_name,
		c.name as category_name
FROM product p
LEFT JOIN product_category_rel pcr on pcr.product_id = p.id
LEFT JOIN category c on c.id = pcr.category_id

------------------------------------王健 2024/8/6 BEGIN--------------------------------------
---直播中带货订单表
CREATE TABLE `tbl_living_take_goods_order` (
	`id` VARCHAR(100) NOT NULL,
	`goods_id` VARCHAR(100) NOT NULL,
	`goods_name` VARCHAR(500) NOT NULL,
	`order_status` INT NOT NULL DEFAULT 0,
	`live_anchor_name` VARCHAR(50) NOT NULL,
	`deal_price` DECIMAL(10,2) NOT NULL DEFAULT 0,
	`goods_count` INT NOT NULL DEFAULT 0,
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`valid` BIT NOT NULL,
	`delete_date` DATETIME NULL DEFAULT NULL
);

ALTER TABLE `tbl_living_take_goods_order`
	ADD PRIMARY KEY (`id`);

------------------------------------王健 2024/8/6 END--------------------------------------

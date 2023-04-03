-----------------------------------------------余建明 2023/XX/XX BEGIN--------------------------------------------

-----------------------------------------------余建明 2023/XX/XX END--------------------------------------------


-----------------------------------------------王健 2023/03/31 BEGIN--------------------------------------------

--------微信视频号订单
CREATE TABLE `tbl_wechatvideo_order_info` (
	`id` VARCHAR(100) NOT NULL,
	`goods_name` VARCHAR(500) NOT NULL,
	`goods_id` VARCHAR(50) NOT NULL,
	`phone` VARCHAR(20) NULL DEFAULT NULL,
	`status_code` VARCHAR(50) NULL DEFAULT NULL,
	`actual_payment` DECIMAL(10,2) NULL DEFAULT NULL,
	`account_receivable` DECIMAL(10,2) NULL DEFAULT NULL,
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`thumb_pic_url` VARCHAR(500) NULL DEFAULT NULL,
	`buyer_nick` VARCHAR(225) NULL DEFAULT NULL,
	`order_type` BIGINT(19) NULL DEFAULT NULL,
	`quantity` INT(10) NULL DEFAULT NULL,
	`belong_emp_id` INT(10) NOT NULL,
	`check_state` INT(10) NULL DEFAULT NULL,
	`check_price` DECIMAL(10,2) NULL DEFAULT NULL,
	`check_date` DECIMAL(10,2) NULL DEFAULT NULL,
	`settle_price` DECIMAL(10,2) NULL DEFAULT NULL,
	`check_by` INT(10) NULL DEFAULT NULL,
	`check_remark` VARCHAR(300) NULL DEFAULT NULL,
	`is_return_back_price` BIT(1) NOT NULL,
	`return_back_price` DECIMAL(12,2) NULL DEFAULT NULL,
	`return_back_date` DATETIME NULL DEFAULT NULL,
	`belong_live_anchor_id` INT(10) NULL DEFAULT NULL,
	`valid` BIT(1) NOT NULL,
	`delete_date` DATETIME NULL DEFAULT NULL,
	PRIMARY KEY (`id`)
);



-----------------------------------------------王健 2023/03/31 END--------------------------------------------
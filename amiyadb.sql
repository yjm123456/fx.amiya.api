


------------------------------------------王健  2024/1/18 BEGIN------------------------------------------

--飞书表格信息
CREATE TABLE `tbl_feishu_table` (
	`id` VARCHAR(50) NOT NULL,
	`app_token` VARCHAR(100) NOT NULL,
	`table_id` VARCHAR(100) NOT NULL DEFAULT '',
	`belong_app_id` VARCHAR(100) NOT NULL DEFAULT '',
	`table_type` INT NOT NULL,
	`live_anchorId` INT NOT NULL,
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`valid` BIT NOT NULL,
	`delete_date` DATETIME NULL DEFAULT NULL
);


--短视频评论数据
CREATE TABLE `tbl_short_video_comments` (
	`id` VARCHAR(50) NOT NULL,
	`comments_id` VARCHAR(500) NULL DEFAULT NULL,
	`comments_user_id` VARCHAR(500) NULL DEFAULT NULL,
	`comments_user_name` VARCHAR(500) NULL DEFAULT NULL,
	`like_count` INT NOT NULL DEFAULT 0,
	`comments` VARCHAR(1000) NULL DEFAULT NULL,
	`comments_date` DATETIME NULL DEFAULT NULL,
	`belong_live_anchor_id` INT NOT NULL DEFAULT 0,
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`valid` BIT NOT NULL DEFAULT 0,
	`delete_date` DATETIME NULL DEFAULT NULL,
	PRIMARY KEY (`id`)
);


---短视频粉丝数据
CREATE TABLE `tbl_short_video_fans_data` (
	`id` VARCHAR(50) NOT NULL,
	`stats_date` DATETIME NOT NULL,
	`new_fans_count` INT NOT NULL DEFAULT 0,
	`total_fans_count` INT NOT NULL DEFAULT 0,
	`belong_live_anchor_id` INT NULL DEFAULT 0,
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`valid` BIT NOT NULL DEFAULT 0,
	`delete_date` DATETIME NULL DEFAULT NULL
);
------------------------------------------王健  2024/1/18 END------------------------------------------

--------------------------------------------------------------------------------------------------------------------------------以上已发布至线上


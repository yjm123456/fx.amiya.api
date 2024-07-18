

------------------------------------王健 2024/7/1 BEGIN--------------------------------------


---内容平台订单添加归属部门
ALTER TABLE `tbl_content_platform_order`
	ADD COLUMN `belong_channel` INT NOT NULL DEFAULT 0 AFTER `customer_type`;

------------------------------------王健 2024/7/1 END--------------------------------------


------------------------------------王健 2024/7/16 BEGIN--------------------------------------

---直播后日运营数据添加线索量
ALTER TABLE `tbl_after_living_daily_target`
	ADD COLUMN `clues` INT NOT NULL DEFAULT 0 AFTER `distribute_consulation`;

---直播后月运营数据添加线索量,累计线索量,线索量目标完成率
ALTER TABLE `tbl_liveanchor_monthly_target_after_living`
	ADD COLUMN `clues_target` INT NOT NULL DEFAULT 0 AFTER `distribute_consulation_completeRate`,
	ADD COLUMN `cumulative_clues` INT NOT NULL DEFAULT 0 AFTER `clues_target`,
	ADD COLUMN `clues_complete_rate` DECIMAL(10,2) NOT NULL DEFAULT 0 AFTER `cumulative_clues`;

------------------------------------王健 2024/7/16 END--------------------------------------
--------------------------------------------------------------------------------------------------------------------------------以上已发布至线上
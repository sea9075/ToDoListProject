# Task List   
## 目的   
管理員可以依照使用者的需求，指派工作任務給相對應的工程師   
## 目標   
1. 使用者須登入後填寫需求單   
2. 管理員需登入後查看需求單，並指派工程師   
3. 工程師需登入後查看查看被指定的需求單，並在完成任務後，勾選`已完成`    
4. 已完成的需求單會回到管理員，管理員確認已完成後勾選`確認完成`    
5. 確認完成的需求單會儲存並保留一個月，一個月後會自動刪除   
   
## 資料庫設計   
1. 使用者資料庫(User)   
    - UserId    
    - UserName   
    - Password   
    - Email   
    - Role   
2. 角色資料庫(Role)   
    - RoleId   
    - RoleName   
    - DisplayNum   
3. 任務單資料庫(JobList)   
    - JobId   
    - Title   
    - Description   
    - Assigned\_to   
    - Status   
    - Created\_at   
    - Complete\_at   
    - Confirmed\_at   
4. 參考資料   
    - ChatGPT   
    - [Bootswatch](https://bootswatch.com/)    
    - [Toastr](https://codeseven.github.io/toastr/)    
   
## 20240628 更新   
1. 新增 Role 角色資料庫   
2. 新增 RoleContraller 的 CRUD   
3. 新增 TempData 和 Toastr   
   
## 20240630 更新   
1. 建立 依賴注入   
2. 變更 檔案結構   
   
## 20240701 更新   
1. 建立 JobList Model   
2. 建立 JobList CRUD   

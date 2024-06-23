# TodoList Demo
## 2024.06.23 更新
* 實作 Repository Pattern
* 實作 Unitofwork
## 設計簡單的 TodoList
包含簡單的功能
* 總攬
* 新增
* 修改
* 刪除
## 總攬
* 可以查看所有的代辦事項
## 新增
* 可以新增新的代辦事項
* 包含以下設定項
    - 標題 [必要]
    - 描述 [非必要]
    - 狀態 [必要，選單，預設啟動]
    - 開始時間 [必要]
    - 結束時間 [非必要]
    - 建立時間 [預設輸入當前時間，無法修改]
## 修改
* 可以修改代辦事項
* 包含以下設定
    - 標題[必要，可修改]
    - 描述[非必要，可修改]
    - 狀態[必要，選單]
    - 開始時間[必要，可修改]
    - 結束時間[非必要，可修改]
    - 建立時間[必要，不可修改]
## 刪除
* 可刪除已建立的代辦事項
## 參考資料
[ASP.NET Core](https://learn.microsoft.com/zh-tw/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-8.0&tabs=visual-studio)

[ChatGPT](https://chatgpt.com/)

[Bootswatch](https://bootswatch.com/)

[Toastr](https://codeseven.github.io/toastr/)

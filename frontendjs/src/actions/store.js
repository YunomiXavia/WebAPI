import { createStore, applyMiddleware, compose } from "redux";
import { thunk } from "redux-thunk";
import { reducers } from "../reducers";
// appyMiddleware(thunk) is used to apply the middleware to the store (make a synchronous functions inside the action creators)
export const store = createStore(
  reducers,
  compose(
    applyMiddleware(thunk)
    // window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__()
  )
);

// ! Nhiệm vụ: Tạo ra một kho dữ liệu tập trung (Redux Store) để quản lý trạng thái (state) của ứng dụng.
/*
- import { createStore, applyMiddleware, compose } from "redux";: Import các hàm cần thiết từ thư viện Redux.
- import thunk from "redux-thunk";: Import middleware Redux Thunk. Thunk cho phép các action creator không chỉ trả về đối tượng action đơn thuần mà còn trả về hàm giúp thực hiện xử lý bất đồng bộ (ví dụ gọi API).
- export const store = createStore({}, compose(applyMiddleware(thunk)));:
    - createStore: Hàm tạo store, nhận reducer chính (chưa có ở đây) và trạng thái ban đầu (mảng rỗng {} ).
    - compose: Hàm tiện ích giúp kết hợp nhiều enhancer, ở đây chỉ có 1.
applyMiddleware(thunk): Tạo enhancer cho Redux store, enhancer bổ sung chức năng sử dụng middleware Thunk cho store.
*/

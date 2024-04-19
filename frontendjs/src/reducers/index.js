import { combineReducers } from "redux";
import { hangHoa } from "./hangHoa";

export const reducers = combineReducers({ hangHoa });

// Gây ra lỗi này nếu để combineReducers({ )} trống: Store does not have a valid reducer. Make sure the argument passed to combineReducers is an object whose values are reducers.

// *combineReducers nhận một đối tượng với các reducer nhỏ hơn làm tham số. Mỗi khóa trong đối tượng là tên của một phần trạng thái và giá trị tương ứng là reducer cho phần trạng thái đó.

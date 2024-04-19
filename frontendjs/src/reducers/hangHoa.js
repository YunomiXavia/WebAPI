import { ACTION_TYPES } from "../actions/hangHoa";

const initialState = {
  list: [],
};

export const hangHoa = (state = initialState, action) => {
  switch (action.type) {
    case ACTION_TYPES.FETCH_ALL:
      return {
        ...state,
        list: [...action.payload],
      };

    case ACTION_TYPES.CREATE:
      return {
        ...state,
        list: [...state.list, action.payload],
      };

    case ACTION_TYPES.UPDATE:
      return {
        ...state,
        list: state.list.map((x) =>
          x.ma_hanghoa === action.payload.ma_hanghoa ? action.payload : x
        ),
      };

    case ACTION_TYPES.DELETE:
      return {
        ...state,
        list: state.list.filter((x) => x.ma_hanghoa !== action.payload),
      };
    case ACTION_TYPES.DELETE_BY_CODE:
      return {
        ...state,
        list: state.list.filter((x) => x.ma_hanghoa !== action.payload),
      };
    default:
      return state;
  }
};

/* eslint-disable @typescript-eslint/no-explicit-any */
import { ACTION_TYPES } from "../actions/hangHoa";

interface HangHoa {
  id: number;
}

interface HangHoaState {
  list: HangHoa[];
}

const initialState: HangHoaState = {
  list: [],
};

export const hangHoa = (state = initialState, action: any) => {
  switch (action.type) {
    case ACTION_TYPES.FETCH_ALL:
      return {
        ...state,
        list: [...(action.payload as HangHoa[])],
      };

    case ACTION_TYPES.CREATE:
      return {
        ...state,
        list: [...state.list, action.payload as HangHoa],
      };

    case ACTION_TYPES.UPDATE:
      return {
        ...state,
        list: state.list.map((x) =>
          x.id === (action.payload as HangHoa).id
            ? (action.payload as HangHoa)
            : x
        ),
      };

    case ACTION_TYPES.DELETE:
      return {
        ...state,
        list: state.list.filter((x) => x.id !== action.payload),
      };

    default:
      return state;
  }
};

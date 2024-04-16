/* eslint-disable @typescript-eslint/no-explicit-any */
import api from "./api";

interface HangHoa {
  id: number;
  ma_hanghoa: string;
  ten_hanghoa: string;
  so_luong: number;
  ghi_chu?: string;
}

export const ACTION_TYPES = {
  CREATE: "CREATE",
  UPDATE: "UPDATE",
  DELETE: "DELETE",
  FETCH_ALL: "FETCH_ALL",
};

const formatData = (data: HangHoa): HangHoa => ({
  ...data,
  so_luong: data.so_luong ? data.so_luong : 0,
});

export const fetchAll = () => (dispatch: any) => {
  //get api request
  api
    .hangHoa()
    .fetchAll()
    .then((response) => {
      console.log(response);
      dispatch({
        type: ACTION_TYPES.FETCH_ALL,
        //@ts-expect-error Missing type definition for response.data
        payload: response.data,
      });
    })
    .catch((err: Error) => console.log(err));
};

export const create =
  (data: HangHoa, onSuccess: () => void) => (dispatch: any) => {
    data = formatData(data);
    api
      .hangHoa()
      .create(data)
      .then((response) => {
        dispatch({
          type: ACTION_TYPES.CREATE,
          //@ts-expect-error Missing type definition for response.data
          payload: response.data,
        });
        onSuccess();
      })
      .catch((err: Error) => console.log(err));
  };

export const update =
  (id: number, data: HangHoa, onSuccess: () => void) => (dispatch: any) => {
    data = formatData(data);
    api
      .hangHoa()
      .update(id, data)
      .then(() => {
        dispatch({
          type: ACTION_TYPES.UPDATE,
          payload: { ...data, id },
        });
        onSuccess();
      })
      .catch((err: Error) => console.log(err));
  };

export const Delete =
  (id: number, onSuccess: () => void) => (dispatch: any) => {
    api
      .hangHoa()
      .delete(id)
      .then(() => {
        dispatch({
          type: ACTION_TYPES.DELETE,
          payload: id,
        });
        onSuccess();
      })
      .catch((err: Error) => console.log(err));
  };

import api from "./api";

export const ACTION_TYPES = {
  CREATE: "CREATE",
  UPDATE: "UPDATE",
  DELETE: "DELETE",
  FETCH_ALL: "FETCH_ALL",
  DELETE_BY_CODE: "DELETE",
};

const formatData = (data) => ({
  ...data,
  so_luong: data.so_luong ? data.so_luong : 0,
});

export const fetchAll = () => (dispatch) => {
  //get api request
  api
    .hangHoa()
    .fetchAll()
    .then((response) => {
      console.log(response);
      dispatch({
        type: ACTION_TYPES.FETCH_ALL,
        payload: response.data,
      });
    })
    .catch((err) => console.log(err));
};

export const create = (data, onSuccess) => (dispatch) => {
  data = formatData(data);
  api
    .hangHoa()
    .create(data)
    .then((response) => {
      dispatch({
        type: ACTION_TYPES.CREATE,
        payload: response.data,
      });
      onSuccess();
    })
    .catch((err) => console.log(err));
};

export const update = (id, data, onSuccess) => (dispatch) => {
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
    .catch((err) => console.log(err));
};

export const Delete = (id, onSuccess) => (dispatch) => {
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
    .catch((err) => console.log(err));
};

export const deleteByCode = (id, onSuccess) => (dispatch) => {
  api
    .hangHoa()
    .deleteByCode(id)
    .then(() => {
      dispatch({
        type: ACTION_TYPES.DELETE_BY_CODE,
        payload: id,
      });
      onSuccess();
    })
    .catch((err) => console.log(err));
};

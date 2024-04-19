import { Button, Grid, TextField, withStyles } from "@material-ui/core";
import { useEffect } from "react";
import useForm from "../hooks/useForm";
import * as actions from "../actions/hangHoa";
import { connect } from "react-redux";
import { useToasts } from "react-toast-notifications";

const styles = (theme) => ({
  root: {
    "& .MuiTextField-root": {
      margin: theme.spacing(2),
      minWidth: 230,
    },
  },
  smMargin: {
    margin: theme.spacing(1),
  },
});

const initialFieldValues = {
  ma_hanghoa: "",
  ten_hanghoa: "",
  so_luong: "",
  ghi_chu: "",
};

const HangHoaForm = ({ classes, ...props }) => {
  //toast msg
  const { addToast } = useToasts();

  //validate()
  //validate({ma_hanghoa:'abc'})
  const validate = (fieldValue = values) => {
    let temp = { ...errors };
    if ("ma_hanghoa" in fieldValue)
      temp.ma_hanghoa = fieldValue.ma_hanghoa ? "" : "This field is required.";
    if ("ten_hanghoa" in fieldValue)
      temp.ten_hanghoa = fieldValue.ten_hanghoa
        ? ""
        : "This field is required.";
    if ("so_luong" in fieldValue)
      temp.so_luong =
        fieldValue.so_luong === "" || /^\d+$/.test(fieldValue.so_luong)
          ? ""
          : "Only numbers are allowed.";
    setErrors({
      ...temp,
    });
    if (fieldValue === values)
      return Object.values(temp).every((x) => x === "");
  };

  const { values, setValues, errors, setErrors, handleInputChange, resetForm } =
    useForm(initialFieldValues, validate, props.setCurrentId);

  const handleSubmit = (e) => {
    e.preventDefault();
    // console.log(values);
    if (validate()) {
      const onSuccess = () => {
        resetForm();
        addToast("Submitted successfully", { appearance: "success" });
      };
      if (props.currentId == 0)
        // window.alert("Submitted");
        props.createHangHoa(values, onSuccess);
      else props.updateHangHoa(props.currentId, values, onSuccess);
    }
  };

  const handleDeleteByCode = (e) => {
    e.preventDefault();
    if (
      window.confirm(
        `Are you sure to delete this mã hàng hoá: ${values.ma_hanghoa_timkiem}`
      )
    ) {
      props.deleteHangHoa(values.ma_hanghoa_timkiem, () =>
        addToast("Deleted successfully", { appearance: "info" })
      );
      resetForm(); // Reset the form fields after deletion
    }
  };

  useEffect(() => {
    if (props.currentId != 0) {
      setValues({
        ...props.hangHoaList.find((item) => item.ma_hanghoa == props.currentId),
      });
      setErrors({});
    }
  }, [props.currentId]);
  return (
    <form
      autoComplete="off"
      noValidate
      className={classes.root}
      onSubmit={handleSubmit}
    >
      {/* Xoá theo tìm kiếm */}
      <Grid container>
        <Grid item xs={5}>
          <TextField
            name="ma_hanghoa_timkiem"
            variant="outlined"
            label="Tìm kiếm theo mã hàng hoá"
            value={values.ma_hanghoa_timkiem}
            onChange={handleInputChange}
          />
        </Grid>
        <Grid item xs={2}>
          <Button
            className={classes.smMargin}
            variant="contained"
            color="secondary"
            onClick={handleDeleteByCode}
          >
            Xóa Theo Mã
          </Button>
        </Grid>
      </Grid>
      {/* Các Input cần thiết */}
      <Grid container>
        <Grid item xs={5}>
          <TextField
            name="ma_hanghoa"
            variant="outlined"
            label="Mã hàng hoá"
            value={values.ma_hanghoa}
            onChange={handleInputChange}
            {...(errors.ma_hanghoa && {
              error: true,
              helperText: errors.ma_hanghoa,
            })}
          />
          <TextField
            name="ten_hanghoa"
            variant="outlined"
            label="Tên hàng hoá"
            value={values.ten_hanghoa}
            onChange={handleInputChange}
            {...(errors.ten_hanghoa && {
              error: true,
              helperText: errors.ten_hanghoa,
            })}
          />
        </Grid>
        <Grid item xs={5}>
          <TextField
            name="so_luong"
            variant="outlined"
            label="Số lượng"
            value={values.so_luong}
            onChange={handleInputChange}
            {...(errors.so_luong && {
              error: true,
              helperText: errors.so_luong,
            })}
          />
          <TextField
            name="ghi_chu"
            variant="outlined"
            label="Ghi Chú"
            value={values.ghi_chu}
            onChange={handleInputChange}
          />
          <div>
            <Button
              variant="contained"
              color="primary"
              type="submit"
              className={classes.smMargin}
            >
              Submit
            </Button>
            <Button
              variant="contained"
              className={classes.smMargin}
              onClick={resetForm}
            >
              Reset
            </Button>
          </div>
        </Grid>
      </Grid>
    </form>
  );
};

const mapStateToProps = (state) => ({
  hangHoaList: state.hangHoa.list,
});

const mapActionToProps = {
  createHangHoa: actions.create,
  updateHangHoa: actions.update,
  deleteHangHoa: actions.Delete,
  deleteHangHoaByCode: actions.deleteByCode,
};

const connector = connect(mapStateToProps, mapActionToProps);
export default connector(withStyles(styles)(HangHoaForm));

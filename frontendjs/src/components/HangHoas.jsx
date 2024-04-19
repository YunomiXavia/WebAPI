import { connect } from "react-redux";
import * as actions from "../actions/hangHoa";
import { useEffect, useState } from "react";
import HangHoaForm from "./HangHoaForm";
import {
  Button,
  ButtonGroup,
  Grid,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  withStyles,
} from "@material-ui/core";
import EditIcon from "@material-ui/icons/Edit";
import DeleteIcon from "@material-ui/icons/Delete";
import { useToasts } from "react-toast-notifications";

const styles = (theme) => ({
  root: {
    "& .MuiTableCell-head": {
      fontSize: "1.25rem",
    },
  },
  paper: {
    margin: theme.spacing(2),
    padding: theme.spacing(2),
  },
});

const HangHoas = ({ classes, ...props }) => {
  // const [maHangHoa, setMaHangHoa] = useState("");
  const [currentId, setCurrentId] = useState("");
  const { addToast } = useToasts();
  const OnDelete = (ma_hanghoa) => {
    if (window.confirm("Are you sure to delete this record?")) {
      props.deleteHangHoa(ma_hanghoa, () =>
        addToast("Deleted successfully", { appearance: "info" })
      );
    }
  };

  useEffect(() => {
    props.fetchAllHangHoas();
  }, []); //componentDidMount

  return (
    <>
      <Paper className={classes.paper} elevation={3}>
        <h1 className="my-3 text-4xl text-center text-bold">
          FORM QUẢN LÝ HÀNG HOÁ
        </h1>
        <Grid container>
          <Grid item xs={6}>
            <HangHoaForm {...{ currentId, setCurrentId }} />
          </Grid>
          <Grid item xs={6}>
            <TableContainer>
              <Table>
                <TableHead className={classes.root}>
                  <TableRow>
                    <TableCell>Mã hàng hoá</TableCell>
                    <TableCell>Tên hàng hoá</TableCell>
                    <TableCell>Số lượng</TableCell>
                    <TableCell>Ghi chú</TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {props.hangHoaList.map((record, index) => {
                    return (
                      <TableRow key={index} hover>
                        <TableCell>{record.ma_hanghoa}</TableCell>
                        <TableCell>{record.ten_hanghoa}</TableCell>
                        <TableCell>{record.so_luong}</TableCell>
                        <TableCell>{record.ghi_chu}</TableCell>
                        <TableCell>
                          <ButtonGroup variant="text">
                            <Button>
                              <EditIcon
                                color="primary"
                                onClick={() => {
                                  setCurrentId(record.ma_hanghoa);
                                }}
                              />
                            </Button>
                            <Button>
                              <DeleteIcon
                                color="secondary"
                                onClick={() => OnDelete(record.ma_hanghoa)}
                              />
                            </Button>
                          </ButtonGroup>
                        </TableCell>
                      </TableRow>
                    );
                  })}
                </TableBody>
              </Table>
            </TableContainer>
          </Grid>
        </Grid>
      </Paper>
    </>
  );
};

const mapStateToProps = (state) => ({
  hangHoaList: state.hangHoa.list,
});

const mapActionToProps = {
  fetchAllHangHoas: actions.fetchAll,
  deleteHangHoa: actions.Delete,
};

const connector = connect(mapStateToProps, mapActionToProps);
export default connector(withStyles(styles)(HangHoas));

// ! Nhiệm vụ: Kết nối component với store Redux.

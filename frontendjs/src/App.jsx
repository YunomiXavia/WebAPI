import "./App.scss";
import { store } from "./actions/store";
import { Provider } from "react-redux";
import HangHoa from "./components/HangHoas";
import { Container } from "@material-ui/core";
import { ToastProvider } from "react-toast-notifications";

function App() {
  return (
    <Provider store={store}>
      <ToastProvider autoDismiss={true}>
        <Container maxWidth="lg">
          <HangHoa></HangHoa>
        </Container>
      </ToastProvider>
    </Provider>
  );
}

export default App;

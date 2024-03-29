import React from "react";
import { render } from "react-dom";
import { createStore, applyMiddleware } from "redux";
import { Provider } from "react-redux";
import { Router } from "react-router";
import { createBrowserHistory } from "history";
import createSagaMiddleware from "redux-saga";
import sagas from "./sagas";
import reducers from "./reducers";

const appContainer = document.querySelector(".js-app");
const sagaMiddleware = createSagaMiddleware();

const store = createStore(reducers, applyMiddleware(sagaMiddleware));

sagaMiddleware.run(sagas);

if (appContainer) {
  render(
    // @ts-ignore - to be fixed
    <Provider store={store}>
      <Router history={createBrowserHistory({})} />
    </Provider>,
    appContainer
  );
}

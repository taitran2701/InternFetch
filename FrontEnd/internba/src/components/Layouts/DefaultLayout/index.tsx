import Header from "./Header";

import * as React from "react";
import Body from "./Body";

export interface IDefaultLayoutProps {}

export default function DefaultLayout() {
  return (
    <div>
      <Header />
      <div className="container-fluid">
        <Body/>
      </div>
    </div>
  );
}

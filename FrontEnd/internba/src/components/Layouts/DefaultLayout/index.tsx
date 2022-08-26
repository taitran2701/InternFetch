import Header from "./Header";
import Sidebar from "./Sidebar";

import * as React from "react";

export interface IDefaultLayoutProps {}

export default function DefaultLayout() {
  return (
    <div>
      <Header />
      <div className="container">
        <Sidebar />
        <div className="content">children</div>
      </div>
    </div>
  );
}

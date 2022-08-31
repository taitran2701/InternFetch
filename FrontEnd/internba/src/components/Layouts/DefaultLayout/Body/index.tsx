import { Fragment } from "react";
import Content from "../../../Content";
import Sidebar from "../../../Sidebar";
import SideRight from "../../../Sideright";
import styles from "./index.module.scss";

function Body() {
  return (
    <Fragment>
      <div className={styles.bodypart}>
        <Sidebar />
        <Content />
        <SideRight />
      </div>
    </Fragment>
  );
}

export default Body;

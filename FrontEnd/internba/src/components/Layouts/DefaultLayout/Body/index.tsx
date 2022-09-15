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
        <Content id={""} content={""} userId={""} />
        <SideRight />
      </div>
    </Fragment>
  );
}

export default Body;

import Content from "../../../Content";
import Sidebar from "../../../Sidebar";
import SideRight from "../../../Sideright";
import styles from "./Body.module.scss";

function Body() {
  return (
    <>
      <div className={styles.bodypart}>
        <div>
          <div className={styles.leftBar}>
            <Sidebar />
          </div>
        </div>
        <div className={styles.Content}>
          <Content />
        </div>
        <div className={styles.Sideright}>
          <SideRight />
        </div>
      </div>
    </>
  );
}

export default Body;

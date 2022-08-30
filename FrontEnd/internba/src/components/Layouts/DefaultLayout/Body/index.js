import Content from "../../../Content";
import Sidebar from "../../../Sidebar";
import SideRight from "../../../Sideright";
import styles from "./Body.module.scss";

function Body() {
  return (
    <>

      <div className={styles.bodypart}>
        <div>
          <Sidebar/>
          <div className={styles.leftBar}>
            
          </div>
          
        </div>
        <div  >
          <Content/>
        </div>
        <div className={styles.Sideright}><SideRight/></div>
      </div>      
    </>
  );
}

export default Body;

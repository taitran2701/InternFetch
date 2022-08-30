import Content from "../../../Content";
import styles from "./Body.module.scss";
import Home from "./Home.module.scss";
import "./Body.scss";

function Body() {
  return (
    <>

      <div className={styles.bodypart}>
        <div className={styles.Sidebar}>
          Sidebar
          <div className={styles.leftBar}>
            
          </div>
          
        </div>
        <div className={Home.NewsFeed} >
          <Content/>
        </div>
        <div className={styles.Sideright}>Sideright</div>
      </div>      
    </>
  );
}

export default Body;

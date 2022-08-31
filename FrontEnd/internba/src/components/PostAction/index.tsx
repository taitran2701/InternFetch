import React from "react";
import styles from "./index.module.scss";

function PostAction() {
  return (
    <React.Fragment>
      <div className={styles.feedActionWrapper}>
        <div className={styles.action}>
          <span
            role="img"
            aria-label="like"
            className={`${styles["emotionIcon"]} ${styles["anticon"]}`}
          ></span>
          <span className={styles.emotionTitle}>Like</span>
        </div>
        <div className={styles.action}>
          <span
            role="img"
            aria-label="like"
            className={`${styles["emotionIcon"]} ${styles["anticon"]}`}
          ></span>
          <span className={styles.emotionTitle}>Comment</span>
        </div>
        <div className={styles.action}>
          <span
            role="img"
            aria-label="like"
            className={`${styles["emotionIcon"]} ${styles["anticon"]}`}
          ></span>
          <span className={styles.emotionTitle}>Share</span>
        </div>
      </div>
    </React.Fragment>
  );
}
export default PostAction;

import React from "react";
import styles from "./index.module.scss";

function Poststyles() {
  return (
    <React.Fragment>
      <div className={styles.commentWrapper}>
        <img
          src="https://lh3.googleusercontent.com/a/AATXAJwKOUIR8zBbhQomf7plXxFDd7K5yJWDBLpYvAMH=s96-c"
          alt=""
        />
        <div>
          <div className={styles.commentBox}>
            <div className={styles.commentTitle}>Huong Lan</div>
            <div className={styles.commentDescription}>Nice</div>
            <div className={`${styles.commentEmotion} ${styles.active}`}>
              <img
                src="https://winka-social-network.netlify.app/static/media/likeCount.5d3594a6.svg"
                alt=""
              />
              <span>7</span>
            </div>
          </div>
          <div className={styles.commentReaction}>
            <span>Like</span>
            <span>Reply</span>
            <span>3 hours ago</span>
          </div>
        </div>
      </div>
      <div className={styles.commentWrapper}>
        <img
          src="https://lh3.googleusercontent.com/a-/AOh14GhctFW94flV3UANfpBO4pciweF_BLt3DHn7Ee9K=s96-c"
          alt=""
        />
        <div>
          <div className={styles.commentBox}>
            <div className={styles.commentTitle}>Manh Cuong</div>
            <div className={styles.commentDescription}>Good job</div>
            <div className={`${styles.commentEmotion} ${styles.active}`}>
              <img
                src="https://winka-social-network.netlify.app/static/media/likeCount.5d3594a6.svg"
                alt=""
              />
              <span>5</span>
            </div>
          </div>
          <div className={styles.commentReaction}>
            <span>Like</span>
            <span>Reply</span>
            <span>2 hours ago</span>
          </div>
        </div>
      </div>
    </React.Fragment>
  );
}
export default Poststyles;

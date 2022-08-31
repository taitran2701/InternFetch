import { Fragment, useState } from "react";
import Card from "./Card.module.scss";
import News from "./News.module.scss";
import Comment from "./Comment.module.scss";
import PostModal from "../modal/postModal/index";
import AddStatus from "../AddStatus";
import PostUser from "../PostUser";
import PostEmotion from "../PostEmotion";
import PostAction from "../PostAction";
import PostComment from "../PostComment";

function Content() {
  const [show, setShow] = useState(false);
  return (
    <div>
      <div className={Card.newsCard}>
        <AddStatus />
      </div>
      <div className={Card.newsCard}>
        <PostUser />
        <div className={News.newsDescription}>
          Let create our first social web
        </div>
        <div className={News.newsImage}>
          <img
            src="https://unica.vn/media/imagesck/1604553244_Social-network-la-gi.jpg?v=1604553244"
            alt=""
          />
        </div>

        <div className={News.newsEmotion}>
          <PostEmotion />
        </div>

        <div className={News.feedAction}>
          <PostAction />
        </div>

        <div className={News.feedComment}>
          <PostComment />
          <div className={News.addComment}>
            <img
              src="https://scontent.fsgn5-6.fna.fbcdn.net/v/t39.30808-6/300376547_5491598224258453_7351247412124304056_n.jpg?stp=dst-jpg_s851x315&_nc_cat=108&ccb=1-7&_nc_sid=dbeb18&_nc_ohc=n6ZxL-YpVwMAX-9WE82&_nc_ht=scontent.fsgn5-6.fna&oh=00_AT-SZy5SSMfyG54liZf8KiXdOgajE2k_A994fgC35z0K6A&oe=63125470"
              alt=""
            />
            <input
              type="text"
              placeholder="Write a public comment"
              className={News.commentInput}
            />
          </div>
        </div>
      </div>
    </div>
  );
}
export default Content;

import modal from "./index.module.scss";
import add from "./addStatusModal.module.scss";

const PostModal = (props: { show: any }) => {
  if (!props.show) {
    return null;
  }
  return (
    <div className={modal.modal}>
      <div className={modal.content}>
        <div className={add.header}>
          <span> Create Post</span>
          <button className={add.closeButton}></button>
        </div>
        <div className={add.body}>
          <div className={add.user}>
            <img
              className={add.avatar}
              src="https://i.pinimg.com/736x/9b/89/2c/9b892c9c099e0c98db5bb9fe5a04d43e.jpg"
              alt=""
            />
            <div className={add.userWrapper}>
              <div className={add.userName}>Tai Tran</div>
              <button>Friend</button>
            </div>
          </div>
          <textarea
            placeholder="What's on your mind?"
            className={add.textArea}
            spellCheck="false"
          ></textarea>
          <div className={add.emojiWrapper}>
            <button className={add.emoji}>
              <img
                src="https://winka-social-network.netlify.app/static/media/smile.802e4e1c.png"
                alt=""
              />
            </button>
          </div>
        </div>

        <div className={modal.footer}>
          <button className={modal.button}>Close</button>
        </div>
      </div>
    </div>
  );
};

export default PostModal;
